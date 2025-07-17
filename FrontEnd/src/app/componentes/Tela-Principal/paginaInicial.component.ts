import { Component } from '@angular/core';

@Component({
  standalone:false,
  selector: 'pagina-inicial',
  templateUrl: './paginaInicial.component.html',
  styleUrls: ['./paginaInicial.component.css']
})
export class PaginaInicialComponent {
  paginaAtual: string = 'home';

  exibirPagina(pagina: string) {
    this.paginaAtual = pagina;
  }
}