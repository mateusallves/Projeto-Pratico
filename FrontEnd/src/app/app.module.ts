import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
//material
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
//componentes
import { AppComponent } from './app.component'
import { ApRoutingModule } from './app-rotas.modulo';
import { FazendaComponent } from './componentes/Fazenda/fazenda.component';
import { ProdutorComponente } from './componentes/Produtor/produtor.component';
import { PaginaInicialComponent } from './componentes/Tela-Principal/paginaInicial.component';
import { MovimentacaoComponente } from './componentes/Movimentacao/movimentacao.component';
import { OperacaoComponent } from './componentes/Operacao/operacao.component';

@NgModule({
  declarations:[
    AppComponent,
    FazendaComponent,
    MovimentacaoComponente,
    ProdutorComponente,
    PaginaInicialComponent,
    OperacaoComponent
  ],
  imports:[
    ApRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatSidenavModule,
    MatButtonModule,
    MatListModule,
    MatDividerModule
  ],
  providers:[],
  bootstrap:[AppComponent]
})

export class AppModule{}