Create database Crud

use crud
create table Usuarios(
id int identity(1,1),
Nombres varchar(50),
Apellidos varchar(50),
Fecha date,
Usuario varchar(50),
Clave varbinary(max)
);

create table Imagenes
(
idUsuario int,
Imagen image
)

create procedure registrar
@Nombres varchar(50),
@Apellidos varchar(50),
@Fecha date,
@Usuario varchar(50),
@Clave varchar(100),
@Patron varchar(50),
@IdUsuario int,
@Imagen image
as
begin
insert into Usuarios values(@Nombres, @Apellidos, @Fecha, @Usuario, ENCRYPTBYPASSPHRASE(@Patron, @Clave));
set @IdUsuario=(select Id from Usuarios where Usuario=@Usuario);
insert into Imagenes values(@IdUsuario,@Imagen)
END


Create procedure Validar

@Usuario varchar(50),
@Clave varchar(100),
@Patron varchar(50)
as
begin
Select * from Usuarios where Usuario = @Usuario and convert(varchar(100), DECRYPTBYPASSPHRASE(@Patron, Clave))=@Clave
END


Create  procedure Perfil
@Id int 
as
begin
select * from Usuarios where id=@Id
select * from Imagenes where idUsuario=@Id
END

Create procedure Eliminar
@Id int 
as
begin
delete from Usuarios where id=@Id
delete from Imagenes where idUsuario = @Id
end

Create procedure CargarImagen
@Id int
as 
begin
select Imagen from Imagenes where idUsuario = @Id
end


Create procedure CambiarContrasenia
@Id int,
@Clave varchar(100),
@Patron varchar (50)
as 
begin
update Usuarios set Clave=(ENCRYPTBYPASSPHRASE(@Patron, @Clave)) where id=@Id
end

create procedure CambiarImagen 
@Id int,
@Imagen image
as
begin
update Imagenes set Imagen=@Imagen where idUsuario =@Id
end
