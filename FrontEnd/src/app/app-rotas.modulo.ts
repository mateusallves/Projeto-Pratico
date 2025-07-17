import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FazendaComponent } from './componentes/Fazenda/fazenda.component';
import { ProdutorComponente } from './componentes/Produtor/produtor.component';
import { PaginaInicialComponent } from './componentes/Tela-Principal/paginaInicial.component';
import { OperacaoComponent } from './componentes/Operacao/operacao.component';
import { MovimentacaoComponente } from './componentes/Movimentacao/movimentacao.component';

const rotas: Routes =[
    { path: 'inicio', component: PaginaInicialComponent },
    { path: 'fazendas', component: FazendaComponent },
    { path: 'produtores', component: ProdutorComponente },
    { path: 'operacoes', component: OperacaoComponent },
    { path: 'movimentacoes', component: MovimentacaoComponente },
    { path: '', redirectTo: '/inicio', pathMatch: 'full' }
];

@NgModule({
    imports:[RouterModule.forRoot(rotas)],
    exports:[RouterModule]
})
export class ApRoutingModule{}

