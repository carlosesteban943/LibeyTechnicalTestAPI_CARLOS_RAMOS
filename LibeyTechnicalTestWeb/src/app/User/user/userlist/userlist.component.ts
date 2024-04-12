import swal from 'sweetalert2';

import { Component, OnInit } from '@angular/core';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { UserDataService } from '../userdataservice';
import { Router } from '@angular/router';


@Component({
    selector: 'app-user-list',
    templateUrl: './userlist.component.html',
    styleUrls: ['./userlist.component.css']
})
export class UserListComponent implements OnInit {
    usersList: LibeyUser[] = [];
    searchTerm: string = "";

    constructor(private router: Router, private userDataService: UserDataService, private libeyUserService: LibeyUserService) { }

    ngOnInit(): void {
        this.searchUsers();

    }

    searchUsers() {
        this.libeyUserService.Find(this.searchTerm).subscribe(response => {
            this.usersList = response;
        });
    }

    editUser(user: LibeyUser) {
        // Aquí puedes implementar la lógica para editar el usuario
        // Por ejemplo, podrías abrir un formulario de edición con los datos del usuario
        // Puedes utilizar un servicio o una función para manejar la edición
        console.log('Editando usuario:', user);

        this.userDataService.setLibeyUser(user);
        this.router.navigate(['/user/maintenance']);
    }

    removeUser(user: LibeyUser) {

        swal.fire({
            title: 'Eliminar usuario',
            text: `¿Estás seguro de que deseas eliminar al usuario ${user.name}?`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Eliminar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            // Si el usuario confirma la eliminación
            if (result.isConfirmed) {
                this.libeyUserService.Delete(user.documentNumber).subscribe(
                    (response) => {
                        console.log("Usuario eliminado exitosamente:", response);

                        swal.fire("Correcto", "El usuario ha sido eliminado!", "success");
                        this.searchUsers();

                    },
                    (error) => {
                        swal.fire("Advertencia", "Error al eliminar usuario", "error");
                    }
                );
                console.log('Eliminando usuario:', user);
            }
        });
    }

}
