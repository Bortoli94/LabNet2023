import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersTableComponent } from './pages/shippers-table/shippers-table.component';
import { CategoriesTableComponent } from './pages/categories-table/categories-table.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {path:'home', component:HomeComponent},
  {path:'shippers', component:ShippersTableComponent},
  {path:'categories', component:CategoriesTableComponent},
  {path:'**',pathMatch: 'full',redirectTo:'/home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
