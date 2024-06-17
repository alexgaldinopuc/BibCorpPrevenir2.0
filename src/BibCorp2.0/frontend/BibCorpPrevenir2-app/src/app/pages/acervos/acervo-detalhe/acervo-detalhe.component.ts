import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewEncapsulation,
  inject,
} from '@angular/core';
import { Acervo } from '../../../shared/models/interfaces/acervo';
import { EmprestimoModalEmprestarComponent } from '../../emprestimos';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AcervoService } from '../../../services/acervo';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from '../../../services/usuario';
import { Usuario } from '../../../shared/models/interfaces/usuario';
import { environment } from '../../../../assets/environments';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Comentario } from '../../../shared/models/interfaces/comentario';
import { ComentarioService } from '../../../services/comentario';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-acervo-detalhe',
  templateUrl: './acervo-detalhe.component.html',
})
export class AcervoDetalheComponent implements OnInit {
  #acervoService = inject(AcervoService);
  #comentarioService = inject(ComentarioService);
  #activevateRouter = inject(ActivatedRoute);
  #dialogRef = inject(MatDialog);
  #spinnerService = inject(NgxSpinnerService);
  #toastrService = inject(ToastrService);
  #usuarioService = inject(UsuarioService);
  #snackBar = inject(MatSnackBar);
  #formBuilder = inject(FormBuilder);

  @Input('rating') public rating: number = 0;
  @Input('starCount') public starCount: number = 5;
  @Input('color') public color: string = 'primary';
  @Output() public ratingUpdated = new EventEmitter();

  public formComentarios = {} as FormGroup;

  public snackBarDuration: number = 2000;
  public ratingArr = [] as any;
  public ratingArr2 = [] as any;

  public acervo = {} as Acervo;
  public usuarioAtivo = {} as Usuario;
  public comentario = {} as Comentario;
  public usuarios = [] as Usuario[];
  public comentariosList = [] as Comentario[];

  public acervoParam = '' as any;
  public fotoURL: string = '';
  public fotoURLComentario: string = '';
  public URLBase = environment.fotoURL;

  public usuarioLogado = false;
  public disabledReservar = false;
  public temComentario = false;

  public abrirDialog(patrimonioId: number) {
    this.#dialogRef.open(EmprestimoModalEmprestarComponent, {
      data: {
        patrimonioId: patrimonioId,
        acervoId: this.acervo.id,
        id: 'Emprestar',
      },
    });
  }

  public get ctrF(): any {
    return this.formComentarios.controls;
  }

  public ngOnInit(): void {
    this.acervoParam = this.#activevateRouter.snapshot.paramMap.get('id');
    this.getUsuarios();

    this.formValidator();

    for (let i = 0; i < this.starCount; i++) {
      this.ratingArr.push(i);
      this.ratingArr2.push(i);
    }

    this.getUserAtivo();
    this.getAcervoById();
    this.getComentarios();
  }

  public formValidator(): void {
    this.formComentarios = this.#formBuilder.group({
      comentarios: [''],
    });
  }

  public getUserAtivo(): void {
    this.#spinnerService.show();

    this.#usuarioService
      .getUsuarioByUserName()
      .subscribe({
        next: (usuarioAtivo: Usuario) => {
          this.usuarioAtivo = usuarioAtivo;
          this.usuarioLogado = true;
          this.fotoURL =
            this.usuarioAtivo.fotoURL === null
              ? '../../../../assets/images/not-available.png'
              : environment.fotoURL + this.usuarioAtivo.fotoURL;
        },
        error: (error: any) => {
          if (error.status == 401) this.usuarioLogado = false;
          else
            this.#toastrService.error('Falha ao recuperar usuario no sistema');
          console.error(error);
        },
      })
      .add(() => this.#spinnerService.hide());
  }

  public getAcervoById(): void {
    this.#spinnerService.show();

    this.#acervoService
      .getAcervoById(+this.acervoParam)
      .subscribe({
        next: (retorno: Acervo) => {
          this.acervo = retorno;
          console.log(this.acervo);
        },
        error: (error: any) => {
          this.#toastrService.error('Erro ao carregar Acervo', 'Erro!');
          console.error(error);
        },
      })
      .add(() => this.#spinnerService.hide());
  }

  public salvarAvaliacao(): void {
    console.log('Usuario Ativo', this.usuarioAtivo);
    if (this.ctrF.comentarios == null || this.ctrF.comentarios == '') {
      this.#toastrService.info('Informe um comentário', 'Erro!');
    } else {
      this.#spinnerService.show();

      this.comentario.acervoId = this.acervo.id;
      this.comentario.avaliacao = this.rating;
      this.comentario.comentarioTxt = this.ctrF.comentarios.value;
      this.comentario.userName = this.usuarioAtivo.userName;
      this.comentario.userId = this.usuarioAtivo.id;
      this.comentario.usuarioId = this.usuarioAtivo.id;

      console.log('comentario', this.comentario);
      this.#comentarioService
        .createComentario(this.comentario)
        .subscribe({
          next: (comentario: Comentario) => {
            this.comentario = comentario;
            this.#toastrService.success(
              'Comentário incluído para o acervo!',
              'Salvo!'
            );
            window.location.reload();
          },
          error: (error: any) => {
            this.#toastrService.error('Erro ao salvar comentario', 'Erro!');
            console.error(error);
          },
        })
        .add(() => this.#spinnerService.hide());
    }
  }

  public obterStatusPatrimonio(_status: boolean): any {
    if (!this.usuarioLogado || this.usuarioAtivo.isAdmin)
      this.disabledReservar = true;
    else if (_status) this.disabledReservar = true;
    else this.disabledReservar = false;
    return _status ? 'Indisponível' : 'Disponível';
  }

  public showIcon(index: number): any {
    if (this.rating >= index + 1) {
      return 'star';
    } else {
      return 'star_border';
    }
  }

  public showIcon2(index: number, contComentario: number): any {
    if (index <= contComentario) {
      return 'star';
    } else {
      return 'star_border';
    }
  }

  public onClick(rating: number): boolean {
    console.log(rating);
    this.#snackBar.open(
      'Sua avaliação ' + rating + ' / ' + this.starCount,
      '',
      {
        duration: this.snackBarDuration,
      }
    );
    this.rating = rating;
    this.ratingUpdated.emit(rating);
    return false;
  }

  public getComentarios(): any {
    this.#spinnerService.show();

    console.log('acervo', this.acervoParam);
    this.#comentarioService
      .getComentariosByAcervoId(this.acervoParam)
      .subscribe({
        next: (comentarios: Comentario[]) => {
          this.comentariosList = comentarios;
          console.log('Lista Comentario', comentarios);
          var lista = this.comentariosList.filter(
            (c) => c.userName == this.usuarioAtivo.userName
          );

          if (lista.length > 0) this.temComentario = true;
          else this.temComentario = false;
        },
        error: (error: any) => {
          this.#toastrService.error('Erro ao buscar comentarios', 'Erro!');
          console.error(error);
        },
      })
      .add(() => this.#spinnerService.hide());
  }

  public getUsuarios(): any {
    this.#spinnerService.show();

    console.log('acervo', this.acervoParam);
    this.#usuarioService
      .getAllUsuarios()
      .subscribe({
        next: (usuarios: Usuario[]) => {
          this.usuarios = usuarios;
        },
        error: (error: any) => {
          this.#toastrService.error('Erro ao buscar comentarios', 'Erro!');
          console.error(error);
        },
      })
      .add(() => this.#spinnerService.hide());
  }
}
