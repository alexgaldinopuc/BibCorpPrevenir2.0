import { Component, inject } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";

import { MatButtonModule } from "@angular/material/button";
import { MatIcon } from "@angular/material/icon";
import { MatMenuModule } from "@angular/material/menu";

import { LoginService, Usuario, UsuarioService } from "../../../usuarios";
import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { environment } from "../../../../assets/environments";

@Component({
  selector: "app-bcp-nav-bar",
  standalone: true,
  imports: [
    MatButtonModule,
    MatIcon,
    MatMenuModule,
    NgxSpinnerModule,
    RouterLink,
    RouterLinkActive,
  ],
  templateUrl: "./bcp-nav-bar.component.html",
  styleUrl: "./bcp-nav-bar.component.scss",
})
export class BcpNavBarComponent {
  #router = inject(Router);
  #loginService = inject(LoginService);
  #spinnerService = inject(NgxSpinnerService);
  #toastrService = inject(ToastrService);
  #usuarioService = inject(UsuarioService);

  public isCollapsed = true;

  public usuarioLogado = false;
  public usuarioAdmin = false;

  public usuarioAtivo = {} as Usuario;

  public fotoURL = "";

  ngOnInit() {
    this.getUsuario();
  }

  public getUsuario(): void {
    this.#spinnerService.show();

    this.#usuarioService
      .getUsuarioByUserName()
      .subscribe({
        next: (usuarioAtivo: Usuario) => {
          this.usuarioAtivo = { ...usuarioAtivo };
          this.usuarioLogado = this.usuarioAtivo.userName ? true : false;
          this.fotoURL =
            this.usuarioAtivo.fotoURL === null
              ? "../../../../../assets/images/not-available.png"
              : environment.fotoURL + this.usuarioAtivo.fotoURL;
          console.log(this.fotoURL);

          this.usuarioAdmin = this.usuarioAtivo.userName === "Admin";
          console.log(this.usuarioLogado, this.usuarioAdmin);
        },
        error: (error: any) => {
          if (error.status == 401) {
          } else {
            this.#toastrService.error("Falha ao logar no sistema");
            console.error(error);
          }
        },
      })
      .add(() => this.#spinnerService.hide());
  }

  public logout(): void {
    this.#loginService.logout();
    this.#router.navigateByUrl("usuarios/login");
  }
}
