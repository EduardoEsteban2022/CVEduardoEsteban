create dataBase PruebaBD;
use PruebaBD;

create table T_cliente(
idCliente int primary key identity not null,
nombres nvarchar(50) not null,  
apellidos nvarchar (50) not null,
fechaNacimiento date not null,
sueldo decimal(18,2) not null
);

go;


----SP Parar ingresar datos 
alter procedure SP_AgregarCliente
@nombres nvarchar(50),
@apellidos nvarchar(50),
@fechaNacimiento date,
@sueldo decimal(18,2)


As
Begin
	
	--para que no muestre el msj de cuantas filas fueron afectadas	
	SET NOCOUNT ON;

    Begin Tran Tadd

    Begin Try

		insert into T_cliente values(@nombres,@apellidos, @fechaNacimiento, @sueldo)
	
        Select 'El Cliente se registro correctamente.'

        COMMIT TRAN Tadd

    End try
    Begin Catch

        select  'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd

    End Catch

END
GO;


--SP Para obtener datos
alter procedure SP_ObtenerClientes
as
begin
	
	begin try

		select idCliente as ID, nombres as NOMBRES, apellidos as APELLIDOS, fechaNacimiento as FECHA_NACIMIENTO, sueldo as SUELDO from T_cliente;		

	end try

	begin catch

		select  'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.' 
			
	end catch

end
go;

-----SP para editar cliente
create procedure SP_EditarCliente
@id int,
@nombres nvarchar(50),
@apellidos nvarchar(50),
@fecha date,
@sueldo decimal(18,2)
as
begin

	SET NOCOUNT ON;

	begin tran cliEdit

	begin try

		update T_cliente set nombres=@nombres, apellidos=@apellidos, fechaNacimiento=@fecha, sueldo=@sueldo where
		idCliente=@id

		commit tran cliEdit

	end try

	begin catch

	   select  'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
       Rollback TRAN cliEdit

	end catch
end
go;


------SP para eliminar clientes

create procedure SP_EliminarCliente
@id int
as
begin

	SET NOCOUNT ON;

	begin tran cliDele

	begin try

		delete T_cliente where idCliente=@id

		commit tran cliDele

	end try

	begin catch

		select  'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN cliDele

	end catch

end 