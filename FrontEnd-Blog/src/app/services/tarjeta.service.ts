import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { Publicacion } from '../models/publicacion';


@Injectable({
  providedIn: 'root'
})
export class TarjetaService {

  public publicacion: Publicacion | undefined;

  myAppUrl = "http://localhost:35448";
  myApiUrl = "api/TarjetaCredito/";
  constructor(private http: HttpClient) {
  }

  guardarTarjeta(tarjeta: TarjetaCredito): Observable<TarjetaCredito>{
    return this.http.post<TarjetaCredito>(this.myAppUrl + this.myApiUrl, tarjeta);
  }

	consultarPublicaciones() {
    let myAppUrl = "http://localhost:35448";
    let myApiUrl = "api/TarjetaCredito/";

		return this.http.get(myAppUrl + myApiUrl,{})
	}

  guardarPublicacion() {
    if (this.publicacion?.Cabecera && this.publicacion.Detalle) {
      if (!this.publicacion.ID) {

        let fecha = new Date()

        let dia = fecha.getDate()
        let mes = fecha.getMonth()
        let anio = fecha.getFullYear()

        this.publicacion.FechaRegistro = `${dia}-${mes}-${anio}`;
        this.publicacion.Categoria = "Externo";

        let myAppUrl = "http://localhost:35448";
        let myApiUrl = "api/TarjetaCredito/";

        return this.http.post(myAppUrl + myApiUrl, {
          titulo : this.publicacion.Cabecera,
          descripcion : this.publicacion.Detalle,
          fecha : this.publicacion.FechaRegistro,
          tipo : this.publicacion.Categoria
        }, {responseType: 'text'}

        )

      }
    } else {
      alert('Son requeridos ingresar la cabecera y el detalle');
    }
  }

  get baseLocal(): Storage {
		return localStorage;
	}


  addPostLocal(publicacion: Publicacion) {
		return new Observable(obs => {
			const datos = JSON.parse(this.baseLocal.getItem('blogInfo'));

			if (datos) {
				datos.push(publicacion);
				const jsonData = JSON.stringify(datos);
				this.baseLocal.setItem('blogInfo', jsonData);
			} else {
				const datos = [];
				datos.push(publicacion);
				const jsonData = JSON.stringify(datos);
				this.baseLocal.setItem('blogInfo', jsonData);
			}


			obs.next();
		});

	}




}




