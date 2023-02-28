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

