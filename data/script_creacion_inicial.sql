/*	::::::::::::::::::::: ORDEN CREACION TABLAS :::::::::::::::::::::
	(De primero a ultimo, todos los nombres en minusculas para respetar Snake Case)
	
	usuarios
	roles
	roles_usuarios
	funcionalidades
	funcionalidades_roles
	
	planes
	afiliados
	historial_afiliados
	
	profesionales
	tipos_especialidades
	especialidades
	especialidades_profesional
	agenda
	
	tipos_cancelaciones
	cancelaciones
	turnos
	bonos
	atenciones
*/
PRINT 'Inicio Script';
PRINT '------------------';
PRINT 'CREANDO ESQUEMA...';
GO


CREATE SCHEMA KFC AUTHORIZATION gd
GO

PRINT 'ESQUEMA CREADO'
PRINT 'CREANDO TABLAS...'

CREATE TABLE KFC.usuarios
          (
                    us_id      INT PRIMARY KEY IDENTITY(1,1)		--No hay que cambiarlo a secuencia? o sacarle el Identity porque lo manejariamos nosotros
                  , nick       VARCHAR(255) UNIQUE NOT NULL
                  , pass       VARBINARY(8000) NOT NULL			--NOTA: Es VarBinary por estar Encriptada la Contraseña por SHA2_256. Se encripta al llenar los datos
                  , habilitado BIT NOT NULL
				  , intentos   INT NOT NULL DEFAULT 0
          )
PRINT '- Creada Tabla usuarios'		   

CREATE TABLE KFC.roles
          (
                    rol_id      INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
                  , habilitado  BIT NOT NULL
          )
PRINT '- Creada Tabla roles'	
           
CREATE TABLE KFC.roles_usuarios
          (
                    us_id  INT NOT NULL REFERENCES KFC.usuarios
                  , rol_id INT NOT NULL REFERENCES KFC.roles
				   ,CONSTRAINT pk_roles_usuarios PRIMARY KEY (us_id, rol_id)
          )
PRINT '- Creada Tabla roles_usuarios'	
           
CREATE TABLE KFC.funcionalidades
          (
                    func_id     INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
          )
PRINT '- Creada Tabla funcionalidades'	
           
CREATE TABLE KFC.funcionalidades_roles
          (
                    rol_id  INT NOT NULL REFERENCES KFC.roles
                  , func_id INT NOT NULL REFERENCES KFC.funcionalidades
				  ,CONSTRAINT pk_funcionalidades_roles PRIMARY KEY (rol_id, func_id)
          )
PRINT '- Creada Tabla funcionalidades_roles'	
           
CREATE TABLE KFC.planes
          (
                    plan_id              INT PRIMARY KEY IDENTITY(1,1)
				  , descripcion VARCHAR(255) NOT NULL
                  , precio_bono_consulta NUMERIC(18,0) NOT NULL
                  , precio_bono_farmacia NUMERIC(18,0) NOT NULL
          )
PRINT '- Creada Tabla planes'	
           
CREATE TABLE KFC.estado_civil
          (
                    estado_id   INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
          )
PRINT '- Creada Tabla estado_civil'	
           
CREATE TABLE KFC.afiliados
          (
                    --afil_id          INT PRIMARY KEY IDENTITY(1,1)
	  afil_id          INT PRIMARY KEY IDENTITY(1,100)
                  , nombre           VARCHAR(255) NOT NULL
                  , apellido         VARCHAR(255) NOT NULL
                  , tipo_doc         VARCHAR(25) NOT NULL CHECK (tipo_doc IN ('DNI', 'LC', 'LE', 'CI', 'PAS')) 
                  , numero_doc       NUMERIC(18,0) NOT NULL
                  , direccion        VARCHAR(255) NULL
                  , telefono         NUMERIC(18, 0) NULL
                  , mail             VARCHAR(255) NULL
                  , sexo             CHAR NOT NULL CHECK (sexo IN ('M', 'F', 'T', 'P'))
                  , fecha_nacimiento DATETIME NOT NULL
                  , estado_id        INT NOT NULL REFERENCES KFC.estado_civil
                  , habilitado       BIT NOT NULL
				  , personas_a_car 	 INT NULL		-- Incluye conyuge, familiars mayores o cantidad hijos
                  , plan_id          INT NOT NULL REFERENCES KFC.planes
                  , us_id            INT NOT NULL REFERENCES KFC.usuarios
          )
PRINT '- Creada Tabla afiliados'	
           
CREATE TABLE KFC.historial_afiliados
          (
                    afil_id       INT NOT NULL REFERENCES KFC.afiliados
                  , fecha         DATETIME
                  , plan_activo   INT NOT NULL REFERENCES KFC.planes
                  , motivo_cambio VARCHAR(255) NOT NULL
				  ,CONSTRAINT pk_historial_afiliados PRIMARY KEY (afil_id, fecha)
          )
PRINT '- Creada Tabla historial_afiliados'	
           
CREATE TABLE KFC.profesionales
          (
                    prof_id          INT PRIMARY KEY IDENTITY(1,1)
                  , nombre           VARCHAR(255) NOT NULL
                  , apellido         VARCHAR(255) NOT NULL
                  , tipo_doc         VARCHAR(25) NOT NULL CHECK (tipo_doc IN ('DNI', 'LC', 'LE', 'CI', 'PAS')) 
                  , numero_doc       NUMERIC(18,0) NOT NULL
                  , direccion        VARCHAR(255) NULL
                  , telefono         NUMERIC(18, 0) NULL
                  , mail             VARCHAR(255) NULL
                  , fecha_nacimiento DATETIME NOT NULL
                  , matricula        VARCHAR(255) NULL
                  , us_id            INT NOT NULL REFERENCES KFC.usuarios
				  , habilitado BIT NOT NULL
          )
PRINT '- Creada Tabla profesionales'	
           
CREATE TABLE KFC.tipos_especialidades
          (
                    tipo_esp_id INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
          )
PRINT '- Creada Tabla tipos_especialidades'	
           
CREATE TABLE KFC.especialidades
          (
                    espe_id     INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
                  , tipo_esp_id INT NOT NULL REFERENCES KFC.tipos_especialidades
          )
PRINT '- Creada Tabla especialidades'	
           
CREATE TABLE KFC.especialidades_profesional
          (
                    espe_id INT NOT NULL REFERENCES KFC.especialidades
                  , prof_id INT NOT NULL REFERENCES KFC.profesionales
				  ,CONSTRAINT pk_especialidades_profesional PRIMARY KEY (espe_id, prof_id)
          )
PRINT '- Creada Tabla especialidades_profesional'	
           
CREATE TABLE KFC.agenda
          (
                    espe_id INT NOT NULL 
                  , prof_id INT NOT NULL
				  , dia		INT NOT NULL CHECK (dia > 0 AND dia < 8)
				  , fecha_desde DATETIME
                  , fecha_hasta DATETIME
                  , hora_desde  TIME(0) -- 0 por Minima precicion Nanosegundos. No queremos tanta precicion
                  , hora_hasta  TIME(0)
				  ,CONSTRAINT fk_agenda_especialidades_profesional FOREIGN KEY(espe_id, prof_id) REFERENCES KFC.especialidades_profesional (espe_id, prof_id)
				  ,CONSTRAINT pk_agenda PRIMARY KEY (espe_id, prof_id, dia, fecha_desde, fecha_hasta, hora_desde, hora_hasta)	-- Habria que ver si puede acortarse la PK
          )
PRINT '- Creada Tabla agenda'	

CREATE TABLE KFC.turnos
          (
                    turno_id   INT PRIMARY KEY IDENTITY(1,1)
                  , fecha_hora DATETIME NOT NULL
				  , hora	   TIME(0)  NOT NULL
                  , afil_id    INT NOT NULL REFERENCES KFC.afiliados
                  , espe_id    INT NOT NULL
                  , prof_id    INT NOT NULL
				  , CONSTRAINT fk_turnos_especialidades_profesional FOREIGN KEY(espe_id, prof_id) REFERENCES KFC.especialidades_profesional (espe_id, prof_id)
          )
PRINT '- Creada Tabla turnos'	
           
CREATE TABLE KFC.tipos_cancelaciones
          (
                    tipo_cancel_id INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion    VARCHAR(255) UNIQUE NOT NULL
          )
PRINT '- Creada Tabla tipos_cancelaciones'	
           
CREATE TABLE KFC.cancelaciones
          (
                    cancel_id      INT PRIMARY KEY IDENTITY(1,1)
                  , turno_id       INT NOT NULL REFERENCES KFC.turnos
                  , detalle_cancel VARCHAR(255) NOT NULL
				  , fecha_cancel   DATETIME
                  , tipo_cancel_id INT NOT NULL REFERENCES KFC.tipos_cancelaciones
          )
PRINT '- Creada Tabla cancelaciones'	
           
CREATE TABLE KFC.bonos
          (
                    bono_id INT PRIMARY KEY IDENTITY(1,1)
                  , plan_id INT NOT NULL REFERENCES KFC.planes
                  , afil_id INT NOT NULL REFERENCES KFC.afiliados
				  , fecha_compra DATETIME NOT NULL
				  , fecha_impresion DATETIME NULL
				  , consumido BIT NOT NULL DEFAULT 0			-- Por defecto (Bonos Nuevos) estan sin consumir
          ) 
PRINT '- Creada Tabla bonos'	
           
CREATE TABLE KFC.atenciones
          (
                    atencion_id  INT PRIMARY KEY IDENTITY(1,1)
                  , turno_id     INT NOT NULL REFERENCES KFC.turnos
                  , hora_llegada	DATETIME NOT NULL
				  , hora_atencion	DATETIME NULL		-- Debe Ser Nullable para poder ingresar solamente hora llegada
                  , sintomas     VARCHAR(255)
                  , diagnostico  VARCHAR(255)
                  , bono_id      INT NOT NULL REFERENCES KFC.bonos
          )
PRINT '- Creada Tabla atenciones'	

PRINT 'Creadas todas las tablas'

































----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'CREANDO FUNCIONES Y PROCEDURES PARA NEGOCIO...'
GO

------------------OBTENER_TODOS_LOS_ROLES------------------
--Proposito: obtiene los roles actuales del sistema
--
--Ingreso: con ID 0 devuelve todos los roles
--
--Egreso: una tabla con la descripcion y el id de los roles
------------------OBTENER_TODOS_LOS_ROLES------------------
CREATE FUNCTION KFC.fun_obtener_roles_usuario(@usuario_id INT)
returns TABLE AS
RETURN
SELECT DISTINCT rol.rol_id
        , rol.descripcion
FROM
          KFC.roles_usuarios AS rol_us
          INNER JOIN
                    KFC.roles AS rol
          ON
                    rol_us.rol_id = rol.rol_id
WHERE
          (
                    @usuario_id     = 0
                    OR rol_us.us_id = @usuario_id
          )
          AND rol.habilitado = 1
;
GO

CREATE FUNCTION KFC.fun_obtener_funcionalidades_usuario(@usuario_id INT, @rol_descripcion VARCHAR(60) )
returns TABLE AS
RETURN
SELECT DISTINCT	 f.descripcion AS fun_descripcion
				, f.func_id
				, r.rol_id
				, r.descripcion AS rol_descripcion 
FROM
          KFC.roles_usuarios AS ru
          INNER JOIN KFC.roles AS r
          ON
                    ru.rol_id = r.rol_id
		  INNER JOIN KFC.funcionalidades_roles fr
		  ON	fr.rol_id = r.rol_id
		  INNER JOIN KFC.funcionalidades f
		  ON	f.func_id = fr.func_id
WHERE
         ru.us_id = @usuario_id
		 AND UPPER(r.descripcion) = UPPER(@rol_descripcion)
;
GO


------------------VALIDAR_USUARIO------------------
--Proposito: verificar el correcto logueo en el sistema
--
--Ingreso: usuario y contraseña
--
--Egreso: el identificador del usuario. Devuelve -1 si no existe el usuario
------------------VALIDAR_USUARIO------------------
CREATE PROCEDURE KFC.pro_validar_usuario(@usuario VARCHAR(30), @contrasenia VARCHAR(30), @rol_desc	VARCHAR(50), @id INT OUTPUT)
AS BEGIN
		BEGIN TRY
			SET  @id = -1;
			
			--Validaciones
			IF NOT EXISTS( SELECT * FROM KFC.usuarios WHERE nick=@usuario ) RAISERROR('Usuario Inexistente',16,1);

			IF NOT EXISTS( SELECT * FROM KFC.usuarios WHERE nick=@usuario AND habilitado=1 ) RAISERROR('Usuario Desactivado',16,1);

			IF NOT EXISTS	( 
							SELECT * FROM KFC.usuarios WHERE nick=@usuario AND pass=HASHBYTES('SHA2_256', @contrasenia) 
							) 
							RAISERROR('Esta Mal la Contrasenia',16,1);


			IF NOT EXISTS	(
							SELECT * FROM KFC.usuarios U 
							INNER JOIN KFC.roles_usuarios ru	ON ru.us_id=u.us_id 
							INNER JOIN KFC.roles r				ON r.rol_id= ru.rol_id
							WHERE U.nick=@usuario AND   UPPER(r.descripcion) =  UPPER(@rol_desc)
							) 
							RAISERROR('El Usuario no tiene Asignado ese Rol',16,1);


			SELECT
					@id = ISNULL(us.us_id,-1)
			FROM
					KFC.usuarios us
					INNER JOIN KFC.roles_usuarios ru
					ON	ru.us_id = us.us_id
					INNER JOIN KFC.roles r
					ON ru.rol_id = r.rol_id
			WHERE
					us.nick           = @usuario
					AND us.pass       = HASHBYTES('SHA2_256', @contrasenia)
					AND us.habilitado = 1
					AND UPPER(r.descripcion) = UPPER(@rol_desc)
			;

			if (@@ROWCOUNT <= 0) RAISERROR('No Pudo Encontrarse un Usuario Activo con ese Nombre, Contrasenia y Rol',16,1);
			if (@id = -1)	RAISERROR('ID Invalido, No Pudo Encontrarse un Usuario Activo con ese Nombre, Contrasenia y Rol',16,1);

		END TRY
		BEGIN CATCH
                    --IF @@trancount > 0
                    --ROLLBACK TRANSACTION;
                    ;THROW
        END CATCH
END;
GO


------------------DESHABILITAR_USUARIO------------------
--Proposito: deshabilita un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------DESHABILITAR_USUARIO------------------
CREATE PROCEDURE kfc.pro_deshabilitar_usuario
          @usu_nick VARCHAR(30)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		UPDATE kfc.usuarios SET habilitado = 0 WHERE nick = @usu_nick;
                    
		COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


------------------HABILITAR_ROL------------------
--Proposito: Habilitar un rol, para que sea útil en el sistema
--
--Ingreso: el identificador del rol
--
--Egreso: -
------------------HABILITAR_ROL------------------
CREATE PROCEDURE kfc.pro_habilitar_rol
          @rol_id INT
AS
BEGIN
	BEGIN TRY
			BEGIN TRANSACTION
			UPDATE kfc.roles SET habilitado = 1 WHERE rol_id = @rol_id;
                    
			COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

------------------DESHABILITAR_ROL------------------
--Proposito: Deshabilitar un rol, para que sea inútil en el sistema
--
--Ingreso: el identificador del rol
--
--Egreso: -
------------------DESHABILITAR_ROL------------------
CREATE PROCEDURE kfc.pro_deshabilitar_rol
          @rol_id INT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
        UPDATE kfc.roles SET habilitado = 0 WHERE rol_id = @rol_id;
                    
        COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

------------------AUMENTAR_INTENTOS------------------
--Proposito: Actualizar la cantidad de errores al loguear con un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------AUMENTAR_INTENTOS------------------
CREATE PROCEDURE kfc.pro_aumentar_intentos
          @usu_nick VARCHAR(30)
AS
BEGIN
	DECLARE @string VARCHAR(60);

	--Solo veo de aumentar intentos si existe el usuario, sino no puedo hacer nada
	IF NOT EXISTS( SELECT * FROM KFC.usuarios u WHERE u.nick = @usu_nick)
	BEGIN
		SET @string = 'No existe el Usuario: ' + @usu_nick;
		RAISERROR(@string, 16, 1);
		RETURN;
	END

	--Veo si el Usuario NO esta Habilitado para dar error. No tiene sentido aumentar intentos usuario inhabilitado
	IF NOT EXISTS( SELECT * FROM KFC.usuarios u WHERE u.nick = @usu_nick AND u.habilitado = 1 )
	BEGIN
		SET @string = 'El Usuario ' + @usu_nick + ' esta Deshabilitado';
		RAISERROR(@string, 16, 1);
		RETURN;
	END

	BEGIN TRY
		BEGIN TRANSACTION
		UPDATE kfc.usuarios SET intentos = intentos +1 WHERE nick = @usu_nick;

		--Al 3er Intento Mal lo Deshabilito al Usuario
		IF (	(	SELECT TOP 1 u.intentos 
					FROM KFC.usuarios u 
					WHERE UPPER(u.nick) = UPPER(@usu_nick)
				) = 3)
		BEGIN
			EXECUTE KFC.pro_deshabilitar_usuario @usu_nick;
		END
                    
		COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


------------------REINICIAR_INTENTOS------------------
--Proposito: Reiniciar la cantidad de errores al loguear con un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------REINICIAR_INTENTOS------------------
CREATE PROCEDURE kfc.pro_reiniciar_intentos
          @usu_nick VARCHAR(30)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
        UPDATE kfc.usuarios SET intentos = 0 WHERE nick = @usu_nick;
                    
        COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

------------------OBTENER_TODAS_LAS_FUNCIONALIDADES------------------
--Proposito: Saber que funciones hay en el sistema
--
--Ingreso: -
--
--Egreso: una tabla con todas las funcionalidades del sistema
------------------OBTENER_TODAS_LAS_FUNCIONALIDADES------------------
CREATE FUNCTION kfc.fun_obtener_todas_las_funcionalidades()
returns TABLE AS
RETURN
SELECT fun.func_id, fun.descripcion FROM kfc.funcionalidades fun;
GO

------------------VERIFICAR_FUNCION_ROL------------------
--Proposito: Revisa que un rol tenga determinada funcionalidad
--
--Ingreso: -
--
--Egreso: 1 = la tiene, 0 = no la tiene
------------------VERIFICAR_FUNCION_ROL------------------
CREATE PROCEDURE kfc.pro_verificar_funcion_rol( @id_func INT,
@id_rol                                              INT)
AS
          BEGIN
                    SELECT
                              1
                    FROM
                              kfc.funcionalidades_roles fr
                    WHERE
                              fr.func_id    = @id_func
                              AND fr.rol_id = @id_rol
                    ;
                    
                    DECLARE @encontrado BIT
                    IF @@rowcount = 0
						BEGIN
								  SET @encontrado = 0
						END
                    ELSE
						BEGIN
								  SET @encontrado = 1
						END
                    RETURN (@encontrado)
          END;
GO


------------------OBTENER_PLANES_AFILIADO------------------
--Proposito: Saber que planes posee un afiliado
--
--Ingreso: identificador del afiliado
--
--Egreso: una tabla con todos los planes que actualmente posee el afiliado,
--			el nombre del afiliado y del titular del beneficio
------------------OBTENER_PLANES_AFILIADO------------------
CREATE FUNCTION kfc.fun_obtener_planes_afiliado( @afiliado_id INT)
returns TABLE
RETURN
(
          SELECT
                    afi.afil_id
                  , concat(afi.apellido,', ', afi.nombre) AS paciente
                  , concat(tit.apellido,', ', tit.nombre) AS titular
                  , pl.plan_id
                  , pl.descripcion
          FROM
                    kfc.afiliados afi
                    INNER JOIN
                              kfc.afiliados tit
                    ON
                              ROUND(afi.afil_id / 100, 0, 1)* 100 + 1 = tit.afil_id			-- Lo que hace es considerar unicamente los Afiliados Originales (no conyuge ni hijos). Para hacerlo redondea el numero de afiliado para "truncarle" los ultimos 2 digitos, luego lo multiplica por cien para restablecer el numero original con 00 ultimos 2 digitos (numero familiar), por eso le suma 1
                    INNER JOIN
                              kfc.planes pl
                    ON
                              pl.plan_id = tit.plan_id
          WHERE
                    afi.habilitado  = 1
                    AND afi.afil_id = @afiliado_id);
GO
-------------------------------------




--------------------------------------
CREATE FUNCTION kfc.fun_obtener_todos_los_planes()
returns TABLE
RETURN
( SELECT pl.plan_id, pl.descripcion FROM kfc.planes pl);
GO

--Obtiene los datos no importa si es profesional o afiliado
CREATE FUNCTION kfc.fun_obtener_datos_usuario(@usuario_id INT)
returns @retorno TABLE( nombre VARCHAR(255), apellido VARCHAR(255) ) AS
BEGIN	
	--Veo si hay Algun Profesional, sino voy a buscar Afiliados
	IF EXISTS	( SELECT * FROM KFC.profesionales p WHERE p.us_id = @usuario_id )
	BEGIN
		INSERT INTO	@retorno
		SELECT TOP 1 p.nombre, p.apellido
		FROM KFC.profesionales p 
		WHERE p.us_id = @usuario_id
	END

	--Ahora voy a ver Afiliados
	ELSE 
	BEGIN
		IF	EXISTS	( SELECT * FROM KFC.afiliados a WHERE a.us_id = @usuario_id )
		BEGIN
			INSERT INTO	@retorno
			SELECT TOP 1 a.nombre, a.apellido
			FROM KFC.afiliados a 
			WHERE a.us_id = @usuario_id
		END
	
		--Si no es ninguno, lleno con Vacio
		ELSE
		BEGIN
			INSERT INTO	@retorno
			VALUES ( '', '' )
		END
	END
	
	RETURN; 
END
GO



------------------OBTENER_ESPECIALIDADES------------------
--Proposito: Saber que especialidades posee un profesional
--
--Ingreso: un identificador de profesional
--
--Egreso: una tabla con todas las especialidades que posee el profesional
------------------OBTENER_ESPECIALIDADES------------------
CREATE FUNCTION kfc.fun_obtener_especialidades_prof(@id_profesional INT)
returns TABLE
RETURN
SELECT
          esp.espe_id
        , esp.descripcion
FROM
          kfc.especialidades_profesional ep
          INNER JOIN
                    kfc.especialidades esp
          ON
                    ep.espe_id= esp.espe_id
WHERE
          (
                    @id_profesional = 0
                    OR ep.prof_id   = @id_profesional
          )
;

GO


CREATE FUNCTION kfc.fun_obtener_especialidades()
returns TABLE
RETURN
SELECT
          esp.espe_id
        , esp.descripcion
FROM
          kfc.especialidades esp
;

GO

------------------OBTENER_PROFESIONALES_POR_ESPECIALIDAD------------------
--Proposito: Saber que profesionales poseen una especialidad
--
--Ingreso: una descripcion de especialidad
--
--Egreso: una tabla con todas los profesionales que poseen esa especialidad
------------------OBTENER_PROFESIONALES_POR_ESPECIALIDAD------------------
CREATE FUNCTION kfc.fun_obtener_profesionales_por_especialidad (@desc_esp VARCHAR(50) )
returns TABLE
RETURN
SELECT
          prof.prof_id
        , concat(prof.apellido,',',prof.nombre) AS profesional
FROM
		kfc.especialidades_profesional ep
		INNER JOIN
				kfc.profesionales prof
		ON
				ep.prof_id= prof.prof_id
		INNER JOIN	KFC.especialidades es
		ON	es.espe_id = ep.espe_id
WHERE es.descripcion = @desc_esp
;
GO


------------------ELIMINAR_ROL_USUARIO------------------
--Proposito: Quitar rol inhabilitados a los usuarios
--
--Ingreso: un identificador de rol inhabilitado
--
--Egreso: -
------------------ELIMINAR_ROL_USUARIO------------------
CREATE PROCEDURE kfc.pro_eliminar_rol_usuario
          @rol_id INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE
			FROM
						kfc.roles_usuarios
			WHERE
						rol_id    = @rol_id
						--Estado este Deshabilitado
						AND 0 = 
								(
								SELECT TOP 1	r.habilitado
								FROM	KFC.roles r
								WHERE	r.rol_id = @rol_id
								)
			;
		COMMIT
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


CREATE PROCEDURE kfc.pro_setear_rol_estado_habilitacion
          @rol_id INT,
		  @estado INT
AS
BEGIN
	BEGIN TRY
			IF (@estado!=0 AND @estado!=1)
				RAISERROR('Estado Invalido para Setear Estado Habilitacion Rol',16,1);

			BEGIN TRANSACTION
			UPDATE kfc.roles SET habilitado = @estado WHERE rol_id = @rol_id;
            --Si yo Queria Deshabilitar, quito Rol a los Usuarios (lo pide el enunciado)
			IF (@estado=0)
				EXECUTE kfc.pro_eliminar_rol_usuario @rol_id;
			       
			COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

CREATE FUNCTION KFC.fun_obtener_id_especialidad(@desc_esp VARCHAR(50) )
RETURNS INT AS
BEGIN
	DECLARE @id INT;
	SET @id = 0;

	SELECT TOP 1	@id = espe_id
	FROM	KFC.especialidades
	WHERE	UPPER(descripcion) = UPPER(@desc_esp)

	return	@id
END;
GO


CREATE FUNCTION KFC.fun_obtener_id_profesional(@nombre VARCHAR(60), @apellido VARCHAR(60)  )
RETURNS INT AS
BEGIN
	DECLARE @id INT;
	SET @id = 0;

	SELECT TOP 1	@id = prof_id
	FROM	KFC.profesionales
	WHERE	UPPER(nombre) = UPPER(@nombre)
	AND		UPPER(apellido) = UPPER(@apellido)

	return	@id
END;
GO

CREATE FUNCTION KFC.fun_obtener_id_profesional_x_user_id(@us_id INT)
RETURNS INT AS
BEGIN
	DECLARE @id INT;
	SET @id = 0;

	SELECT TOP 1	@id = prof_id
	FROM	KFC.profesionales
	WHERE	us_id = @us_id

	return	@id
END;
GO

------------------OBTENER_TURNOS_DEL_DIA------------------
--Proposito: Obtener los turnos "ocupados" de un dia
--
--Ingreso: un identificador de profesional, otro de especialidad y un día
--
--Egreso: una tabla con la fecha, hora, paciente, doctor y especialidad
------------------OBTENER_TURNOS_DEL_DIA------------------
CREATE FUNCTION KFC.fun_obtener_turnos_del_dia (@especialidad INT,
												@profesional  INT,
												@fecha		   DATE)
returns TABLE
RETURN
(
          SELECT
                    CONVERT (DATE,t.fecha_hora)        AS fecha
                  , CONVERT (TIME,t.hora)              AS hora
                  , CONCAT(a.apellido, ', ', a.nombre) AS paciente
                  , CONCAT(a.apellido, ', ', a.nombre) AS doctor
                  , esp.descripcion                    AS especialidad
          FROM
                    KFC.turnos t
                    INNER JOIN
                              kfc.afiliados a
                    ON
                              t.afil_id = a.afil_id
                    INNER JOIN
                              kfc.profesionales pr
                    ON
                              pr.prof_id = t.prof_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = t.espe_id
			WHERE	t.prof_id = @especialidad
			AND		t.espe_id  = @profesional
			AND		CONVERT (DATE, t.fecha_hora) = @fecha
)
GO



------------------OBTENER_BONOS_AFILIADO------------------
CREATE FUNCTION KFC.fun_obtener_bonos_afiliado(@afiliado_id INT)
returns TABLE
RETURN
(
          SELECT
                    CONVERT( VARCHAR, b.bono_id) AS numero_bono
          FROM
                    kfc.bonos b
          WHERE
                    b.afil_id  IN (
								--Esto devuelve el grupo familiar completo.
								SELECT afil_id FROM afiliados 
								WHERE floor(afil_id/100) = floor(@afiliado_id/100) AND habilitado = 1 )
                    AND b.consumido = 0
					AND b.plan_id IN (SELECT plan_id FROM afiliados
									  WHERE afil_id = @afiliado_id)
);
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve el 'Id Afilidado' (con el Id despues consulto turnos en otra función).
CREATE FUNCTION KFC.fun_retornar_id_afildo_por_id(@nombre VARCHAR(255), @apellido VARCHAR(255), @us_id INT)
returns INT AS
BEGIN
          DECLARE @Afil_id INT;
          SELECT TOP 1
                    @Afil_id = ISNULL(Afil_id,0)
          FROM
                    KFC.afiliados Afi
          WHERE
                    Afi.nombre         = UPPER(@nombre)
                    AND Afi.apellido   = UPPER(@apellido)
					AND Afi.us_id 	   = @us_id
                    AND Afi.habilitado = 1
          ;
          
          RETURN @Afil_id;
END;
GO

--Devuelve ID Titular de un Afiliado
CREATE FUNCTION kfc.obtener_titular (@afil_id INT)
RETURNS INT
AS
BEGIN
	DECLARE @id INT;
	SELECT @id = floor(@afil_id/100)*100 + 1;
	RETURN @id;
END;
GO

--Con Valor 0 de Documento Trae a Todos
CREATE FUNCTION KFC.obtener_afiliados_filtros(@nombre VARCHAR(255), @apellido VARCHAR(255), @documento NUMERIC(18,0), @flag_buscar_titulares BIT)
returns TABLE
RETURN
(
          SELECT
                    Afi.afil_id, Afi.nombre, Afi.apellido, Afi.numero_doc, Afi.mail
					
          FROM
                    KFC.afiliados Afi
          WHERE
		  
                    Afi.nombre         LIKE '%' + UPPER(@nombre) + '%'
                    AND Afi.apellido   LIKE '%' + UPPER(@apellido) + '%'
					AND (
						@documento = 0
						OR
						--Permito Buscar parcialmente por el DNI
						CONVERT(VARCHAR, Afi.numero_doc) LIKE '%' + CONVERT(VARCHAR, @documento) + '%'
						)
                    AND Afi.habilitado = 1
					--Si busco o no Solamente Titulares, quedo medio feo
					AND (
						@flag_buscar_titulares = 0		--No busco titulares
						OR
						--Veo si el Titular de este afiliado es el mismo, en ese caso es un titular
						KFC.obtener_titular(Afi.afil_id) = Afi.afil_id
						)
);
GO


CREATE FUNCTION KFC.fun_obtener_turnos_sin_diagnostico_profesional(@afil_nombre VARCHAR(255), @afil_apellido VARCHAR(255), @prof_nombre VARCHAR(50), @prof_apellido VARCHAR(50) , @prof_especialidad VARCHAR(50) )
returns TABLE
RETURN
(
          SELECT
					Afi.nombre AS "Afil_Nombre", Afi.apellido AS "Afil_Apellido"
					, planes.descripcion
					, t.hora
					, prof.nombre AS "Prof_Nombre", prof.apellido AS "Prof_Apellido"
					, t.turno_id
					, Afi.afil_id
					, planes.plan_id
          FROM
                    KFC.afiliados Afi
					INNER JOIN KFC.planes planes
					ON planes.plan_id = Afi.plan_id
					INNER JOIN KFC.turnos t
					ON t.afil_id = afi.afil_id
					INNER JOIN KFC.profesionales prof
					ON prof.prof_id = t.prof_id
					INNER JOIN KFC.especialidades e
					ON e.espe_id = t.espe_id
          WHERE
		  
                    Afi.nombre			LIKE '%' + UPPER(@afil_nombre) + '%'
                    AND Afi.apellido	LIKE '%' + UPPER(@afil_apellido) + '%'
					--AND Afi.habilitado = 1
					AND	prof.nombre     LIKE '%' + UPPER(@prof_nombre) + '%'
                    AND prof.apellido   LIKE '%' + UPPER(@prof_apellido) + '%'
					AND e.descripcion   LIKE '%' + UPPER(@prof_especialidad) + '%'
					--Solo Traigo Turnos sin Diagnostico ni Llegada
					AND t.turno_id NOT IN	(
											SELECT	turno_id
											FROM	KFC.atenciones
											)
                    
);
GO

CREATE FUNCTION KFC.fun_obtener_turnos_con_llegada(@afil_nombre VARCHAR(255), @afil_apellido VARCHAR(255), @documento VARCHAR(18), @prof_id INT)
returns TABLE
RETURN
(
          SELECT
                    A.nombre
                  , A.apellido
                  , A.numero_doc
                  , T.fecha_hora
                  , T.turno_id
                  , E.descripcion
          FROM
                    KFC.afiliados A
                    INNER JOIN
                              KFC.turnos T
                    ON
                              T.afil_id = A.afil_id
                    INNER JOIN
                              KFC.profesionales P
                    ON
                              P.prof_id = T.prof_id
                    INNER JOIN
                              KFC.especialidades E
                    ON
                              E.espe_id = T.espe_id
                    INNER JOIN
                              KFC.atenciones AT
                    ON
                              AT.turno_id = T.turno_id
          WHERE
                    A.nombre              LIKE '%' + UPPER(@afil_nombre) + '%'
                    AND A.apellido        LIKE '%' + UPPER(@afil_apellido) + '%'
                    AND A.numero_doc      LIKE '%' + @documento + '%'
                    AND P.prof_id            = @prof_id
                    AND AT.sintomas    IS NULL
                    AND AT.diagnostico IS NULL
);
GO

--SELECT * FROM KFC.fun_obtener_turnos_sin_diagnostico_profesional('','','lara','GIMÉNEZ','')
--SELECT * FROM KFC.fun_obtener_turnos_sin_diagnostico_profesional('','','','','')

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve el 'Id Afilidado' (con el Id despues consulto turnos en otra función).
CREATE FUNCTION KFC.fun_retornar_id_afildo(@nombre VARCHAR(255), @apellido VARCHAR(255), @dni INT)
returns INT AS
BEGIN
          DECLARE @Afil_id INT;
          SELECT TOP 1
                    @Afil_id = ISNULL(Afil_id,0)
          FROM
                    KFC.afiliados Afi
          WHERE
                    Afi.nombre         = UPPER(@nombre)
                    AND Afi.apellido   = UPPER(@apellido)
					--AND Afi.us_id 	   = @us_id
                    AND Afi.habilitado = 1
          ;
          
          RETURN @Afil_id;
END;
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve los 'Turnos' del afiliado con un profesional.	
CREATE FUNCTION KFC.fun_devolver_turnos_prof_afildo(@Afil_id INT,@Prof_id INT)
returns TABLE AS
RETURN
(
          SELECT
                    turno_id
                  , fecha_hora
                  , hora
          FROM
                    KFC.turnos
          WHERE
                    afil_id     = @Afil_id
                    AND prof_id = @Prof_id 
);
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Graba los 'Sintomas/Diagnostico' de la atención.	
CREATE PROCEDURE KFC.pro_grabar_resultado_atencion
          @turno_id INT
          ,
          @sintomas VARCHAR(255)
          ,
          @diagnostico VARCHAR(255)
		  ,
		  @hora_llegada DATETIME
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
        UPDATE
                    kfc.atenciones
        SET       sintomas    = @sintomas
                , diagnostico = @diagnostico
				, hora_llegada = @hora_llegada
        WHERE
                    turno_id = @turno_id
        COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


--Funcionalidad COMPRAR BONOS. Devuelve precio del 'bono consulta' (del mismo plan que tiene el afiliado titular).
CREATE FUNCTION KFC.fun_devolver_precio_bono(@afiliado_id INT)
returns INT AS
BEGIN
          DECLARE @precio INT;
          SET @precio = 0;
          SELECT
                    @precio = p.precio_bono_consulta
          FROM
                    KFC.afiliados a
                    INNER JOIN
                              KFC.planes p
                    ON
							 -- Con la funcion de abajo se valida el afiliado titular
                              --a.plan_id = p.plan_id AND
							  p.descripcion = ( SELECT descripcion FROM KFC.fun_obtener_planes_afiliado(@afiliado_id) )
          WHERE
                    a.afil_id = @afiliado_id
          RETURN @precio;
END;
GO

--Funcionalidad COMPRAR BONOS. Crea 'Bono' comprado por el afiliado (bono del mismo plan que tiene el afiliado).
CREATE PROCEDURE KFC.pro_comprar_bono(@afiliado_id INT, @fecha_formato_string VARCHAR(30) )
AS
BEGIN
	DECLARE @PlanUsuario INT;
	DECLARE @fecha DATETIME;
		
	SET @fecha = CONVERT(DATETIME, @fecha_formato_string, 102);

	SELECT @PlanUsuario = Plan_id
	FROM   KFC.Afiliados
	WHERE  afil_id = @afiliado_id;

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO KFC.bonos(plan_id,afil_id,fecha_compra) VALUES (@PlanUsuario,@afiliado_id, @fecha);
		COMMIT;
	END TRY
	BEGIN CATCH
                IF @@trancount > 0
                ROLLBACK TRANSACTION;

				PRINT 'Bono No Ingresado. Fecha ' + CONVERT(varchar,@fecha,102)
                ;THROW
    END CATCH
END;
GO

/*
--Funcionalidad COMPRAR BONOS. Devuelve 'Id Afilaido' y su 'Nombre' para el caso de que administrativo realiza la compra de bonos en nombre de un afiliado.
CREATE function KFC.fun_devolver_afiliado_y_su_nombre(@Usuario_id INT)
returns table AS
return ( 
Select afil_id, nombre, apellido
from KFC.afiliados
where us_id = @Usuario_id );
go
*/

--Funcionalidad ABM AFILIADOS. Devuelve los 'Afiliado' completo con todos los datos.	
CREATE FUNCTION KFC.fun_devolver_afiliado(@mail VARCHAR(255))
returns TABLE AS
RETURN
(
          SELECT
			afil_id,
			nombre,
			apellido,
			tipo_doc,
			numero_doc,
			direccion,
			telefono,
			mail,
			sexo,
			fecha_nacimiento,
			estado_id,
			habilitado,
			personas_a_car,
			plan_id,
			us_id
          
		  FROM
                    KFC.afiliados
          WHERE
                    mail = @mail
);

GO

--Funcionalidad ABM AFILIADOS. modifica 'Afiliado' completo con todos los datos.	
CREATE PROCEDURE KFC.pro_modificar_afiliado(	@afiliado_id INT,
											@nombre                                              VARCHAR(255),
											@apellido                                            VARCHAR(255),
											@tipo_doc                                            VARCHAR(255),
											@numero_doc                                          NUMERIC(18,0),
											@direccion                                           VARCHAR(255),
											@telefono                                            NUMERIC(18,0),
											@mail                                                VARCHAR(255),
											@sexo                                                CHAR(1),
											@fecha_nacimiento                                    DATETIME,
											@estado_id                                           INT,
											@habilitado                                          BIT,
											@personas_a_car                                      INT,
											@plan_id                                             INT,
											@us_id                                               INT
										)
AS
BEGIN
	BEGIN TRY		 
		BEGIN TRANSACTION
		UPDATE
          kfc.afiliados
		SET       nombre           = @nombre
				, apellido         = @apellido
				, tipo_doc         = @tipo_doc
				, numero_doc       = @numero_doc
				, direccion        = @direccion
				, telefono         = @telefono
				, mail             = @mail
				, sexo             = @sexo
				, fecha_nacimiento = @fecha_nacimiento
				, estado_id        = @estado_id
				, habilitado       = @habilitado
				, personas_a_car   = @personas_a_car
				, plan_id          = @plan_id
				, us_id            = @us_id
		WHERE
				  afil_id = @afiliado_id

		if @@ROWCOUNT = 0
			BEGIN
				ROLLBACK TRANSACTION;
				RAISERROR ('Afiliado inexistente',16,1);
				RETURN;
			END;

		COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

--Funcionalidad ABM ROLES. Crea 'Rol'
CREATE PROCEDURE KFC.pro_crear_rol(@descripcion VARCHAR(255), @id int OUTPUT)
AS
    BEGIN

		DECLARE @Habilitado BIT;
		
		SET @Habilitado = 1;

		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO KFC.roles(descripcion, habilitado) VALUES (@descripcion, @Habilitado)
			COMMIT;

			SELECT TOP 1 @id = rol_id
			FROM	KFC.roles 
			WHERE	descripcion = @descripcion
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

					PRINT 'Rol No Ingresado'
                    ;THROW
        END CATCH
    END;
GO

--Funcionalidad ABM ROLES. Retorna todos los 'Roles', para luego elegir uno e ir asignandole funcionalidades
CREATE FUNCTION kfc.fun_obtener_todas_los_roles()
returns TABLE AS
RETURN
SELECT r.rol_id, r.descripcion, r.habilitado
FROM kfc.roles r;

GO

CREATE FUNCTION KFC.fun_retornar_id_funcionalidad(@func_desc VARCHAR(60))
returns INT AS
BEGIN
			DECLARE @func_id INT;
			SET @func_id = 0;

			SELECT	@func_id = f.func_id
			FROM	KFC.funcionalidades f
			WHERE	UPPER(f.descripcion) = UPPER(@func_desc)

			/*
			IF (@func_id <= 0)
				BEGIN
				DECLARE @string VARCHAR(100);
				SET @string = 'No existe una Funcionalidad con el nombre' + @func_desc
				RAISERROR(@string,16,1);
				END
			*/
          
          RETURN @func_id;
END;
GO

CREATE FUNCTION KFC.fun_retornar_id_rol(@rol_nombre VARCHAR(60))
returns INT AS
BEGIN
			DECLARE @rol_id INT;
			SET @rol_id = -1;

			SELECT	@rol_id = r.rol_id
			FROM	KFC.roles r
			WHERE	UPPER(r.descripcion) = UPPER(@rol_nombre)

			/*
			IF (@@rol_id <= 0)
				BEGIN
				DECLARE @string VARCHAR(100);
				SET @string = 'No existe un Rol con el nombre' + @@rol_nombre
				RAISERROR(@string,16,1);
				END
			*/
          
          RETURN @rol_id;
END;
GO


------------------OBTENER_FUNCION_ROL------------------
--Proposito: Saber que funciones puede realizar un determinado rol
--
--Ingreso: el identificador del rol
--
--Egreso: una tabla con las funciones de ese rol
------------------OBTENER_FUNCION_ROL------------------
CREATE FUNCTION kfc.fun_obtener_funcion_rol( @id_rol INT)
returns TABLE AS
RETURN
SELECT
          fr.func_id
        , fun.descripcion
FROM
          kfc.funcionalidades_roles fr
          INNER JOIN
                    kfc.funcionalidades fun
          ON
                    fr.func_id = fun.func_id
WHERE
          fr.rol_id = @id_rol
;
GO

CREATE FUNCTION kfc.fun_obtener_habilitacion_rol( @id_rol INT)
returns BIT AS
BEGIN
			DECLARE @rol_habilit BIT;
			SET @rol_habilit = 0;

			SELECT	@rol_habilit = r.habilitado
			FROM	KFC.roles r
			WHERE	r.rol_id = @id_rol
          
          RETURN @rol_habilit;
END;
GO


--Funcionalidad ABM ROLES. Asigna una 'Funcionalidad' a un rol
CREATE PROCEDURE KFC.pro_crear_funcionalidad_de_rol(@func_desc VARCHAR(60) , @rol_id INT)
AS
BEGIN

	DECLARE @func_id INT;
	SELECT @func_id = KFC.fun_retornar_id_funcionalidad(@func_desc);

	SELECT * FROM KFC.funcionalidades_roles
	where rol_id = @rol_id
	and func_id = @func_id;

	IF (@@rowcount = 0)
	BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO KFC.funcionalidades_roles(func_id,rol_id) VALUES (@func_id, @rol_id)
			COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;

			PRINT 'Funcionalidad_Rol No Ingresada';
			;THROW
	END CATCH
END;
GO

--Funcionalidad ABM ROLES. Quita una 'Funcionalidad' a un rol
CREATE PROCEDURE KFC.pro_quitar_funcionalidad_de_rol(@func_desc VARCHAR(60), @rol_id INT)
AS
BEGIN

	DECLARE @func_id INT;
	SELECT @func_id = KFC.fun_retornar_id_funcionalidad(@func_desc);

	SELECT	@func_id = f.func_id
	FROM	KFC.funcionalidades f
	WHERE	f.descripcion = @func_desc

	SELECT * FROM KFC.funcionalidades_roles
	where rol_id = @rol_id
	and func_id = @func_id;

	IF @@rowcount != 0
		BEGIN TRY	
				BEGIN TRANSACTION
					DELETE
					FROM KFC.funcionalidades_roles
					WHERE func_id = @func_id and rol_id = @rol_id;
				COMMIT;
		END TRY
		BEGIN CATCH
				IF @@trancount > 0
				ROLLBACK TRANSACTION;
				;THROW
		END CATCH
	ELSE
		RAISERROR('No existe Funcionalidad_Rol',16,1);
END;
GO

--Funcionalidad ABM ROLES. Baja lógica de un 'Rol' y quita rol a usuarios que lo tengan.
CREATE PROCEDURE KFC.pro_baja_logica_rol(@rol_id INT)
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE kfc.roles SET habilitado = 0 WHERE rol_id = @rol_id;
				if @@ROWCOUNT = 0
					BEGIN
						PRINT 'No se pudo dar de baja rol';
						RETURN;
					END;
				else
					DELETE
					FROM KFC.roles_usuarios
					WHERE rol_id = @rol_id;
			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;
                    ;THROW
        END CATCH
    END;

GO
	


------------------DESHABILITAR_ROL_USUARIOS------------------
--Proposito: Dado el ID de un rol, quitarselo a los usuarios que lo contengan y luego deshabilitarlo
--
--Ingreso: id de rol a deshabilitar
------------------DESHABILITAR_ROL_USUARIOS------------------
CREATE PROCEDURE KFC.pro_deshabilitar_rol_usuarios
          @id_rol INT
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE 
				FROM KFC.roles_usuarios
				WHERE rol_id = @id_rol
                
				 EXECUTE pro_deshabilitar_rol @id_rol
			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;
                    ;THROW
        END CATCH
    END;
GO

------------------OBTENER_TURNOS_PROFESIONAL------------------
--Proposito: Consultar los horarios disponibles para un profesional en un determinado dia (horarios dentro de rango definido para ese dia y que no estan ocupados)
--
--Ingreso: id del profesional a consultar horarios y la fecha (formato Año-Mes-Dia) del dia donde quiere ver que horarios hay disponibles 
--Egreso:	Una Tabla de unica columna Horarios disponibles (formato Varchar) (multiples filas cada una con un horario disponible). Necesito que sera Varchar para evitar problemas de conversion contra la aplicacion
------------------OBTENER_TURNOS_PROFESIONAL------------------

CREATE FUNCTION KFC.fun_obtener_turnos_profesional( @prof_nombre VARCHAR(60), @prof_apellido VARCHAR(60), @desc_esp VARCHAR(50), @fecha_text VARCHAR(60) )
returns @retorno TABLE (
						  fecha  VARCHAR(60)
						, horario_disponible VARCHAR(60)
						, nombre VARCHAR(60)
						, apellido VARCHAR(60)
						, especialidad VARCHAR(50)
) AS
--Uso la Variable "@retorno" tipo Tabla para generar los Horarios Disponibles en base al Rango de Horarios Posibles
BEGIN
/*
CREATE PROCEDURE KFC.fun_obtener_turnos_profesional( @prof_nombre VARCHAR(60), @prof_apellido VARCHAR(60), @desc_esp VARCHAR(50), @fecha_text VARCHAR(60) ) AS
BEGIN
	Declare @retorno TABLE (
						  fecha  VARCHAR(60)
						, horario_disponible VARCHAR(60)
						, nombre VARCHAR(60)
						, apellido VARCHAR(60)
						, especialidad VARCHAR(50)
)
*/
	DECLARE @hora_desde TIME, @hora_hasta TIME, @hora_reinicio TIME
	DECLARE	@fecha_desde DATETIME, @fecha_hasta DATETIME
	DECLARE @dia INT
	DECLARE @nombre VARCHAR(60), @apellido VARCHAR(60), @especialidad VARCHAR(50)
	--SET @fecha = CONVERT(DATE,@fecha_text,102)
	


	--Me traigo el Rango de Fechas y Horarios Posibles dentro de un Cursor
	DECLARE rango_fechas_horarios CURSOR FOR (
		SELECT  a.fecha_desde, a.fecha_hasta ,a.dia, a.hora_desde, a.hora_hasta, p.nombre, p.apellido, e.descripcion
		FROM	KFC.agenda a
				INNER JOIN KFC.profesionales p
				ON a.prof_id = p.prof_id
				INNER JOIN KFC.especialidades e
				ON e.espe_id = a.espe_id
		WHERE	p.nombre         LIKE '%' + UPPER(@prof_nombre)		+ '%'
		AND		p.apellido       LIKE '%' + UPPER(@prof_apellido)	+ '%'
		AND (
			@fecha_text = '' 
			OR		(
					--Convierto para que solo compare por Año-Mes-Dia
							CONVERT(DATE,a.fecha_desde) <= CONVERT(DATE,@fecha_text, 102)
					AND		CONVERT(DATE,a.fecha_hasta) >= CONVERT(DATE,@fecha_text, 102)
					)
			)
		AND		UPPER(e.descripcion)	LIKE '%' + UPPER(@desc_esp)		+ '%'
		--Considero que si hay un turno el ultimo Dia, es que estan usados todos, sino lo considero OK
		AND NOT EXISTS	(
						SELECT	1
						FROM	KFC.turnos t
						WHERE	t.prof_id = p.prof_id
						AND		t.espe_id = e.espe_id
						AND		CONVERT(DATE, t.fecha_hora) = CONVERT(DATE, a.fecha_hasta)
						)
	)

	OPEN rango_fechas_horarios

	--Por cada resultado del Cursor (cada rango de fechas) calculo los turnos de 30 minutos para cada dia
	FETCH NEXT FROM rango_fechas_horarios INTO @fecha_desde, @fecha_hasta, @dia, @hora_desde, @hora_hasta, @nombre, @apellido, @especialidad
	WHILE (@@FETCH_STATUS = 0)		--Mientras haya datos
	BEGIN
			--Guardo la Hora para Resetearla por cada Ciclo de Semana
			SET @hora_reinicio = @hora_desde


			--Recorro los Dias de la Semana de este Rango de Fechas (Uso el While para Crear un FOR)
			WHILE ( CONVERT(DATE,@fecha_desde) <= CONVERT(DATE,@fecha_hasta) )
			BEGIN
					--Restablesco Hora de Inicio de la Semana
					SET @hora_desde = @hora_reinicio

					--En caso que el Rango empieze antes del Dia establecido, aumento hasta el dia mismo
					WHILE ( DATEPART(WEEKDAY, @fecha_desde) != @dia )
					BEGIN
							--Aumento 1 dia
							SET @fecha_desde = DATEADD(DAY, 1, @fecha_desde)
					END
					----------------------------------------------------------
					-- Ahora estamos parados justo en el Dia de la semana del Turno
					----------------------------------------------------------
					

					--Aca Diferencio la Fecha si no es nula o si lo es. Si es nula, no comparo fecha, si es nula me fijo que sea la misma fecha a la pedida
					--PRINT 'Comparo @fecha_text=' + @fecha_text + ' @fecha_desde=' + CONVERT(VARCHAR,@fecha_desde)
					IF( (@fecha_text = '' ) OR ( CONVERT(DATE,@fecha_text, 102)=CONVERT(DATE,@fecha_desde)) )
					BEGIN 

						--Inserto Horarios Disponibles, cada 30 minutos (Uso el While para Crear un FOR)
						WHILE ( DATEDIFF(MINUTE, @hora_desde, @hora_hasta) != 0 )
						BEGIN
							--PRINT CONVERT(VARCHAR,@fecha_desde) + ' ' + CONVERT(VARCHAR,@hora_desde)
							INSERT INTO @retorno (fecha , horario_disponible, nombre, apellido, especialidad) 
							VALUES	( 
									CONVERT(VARCHAR, @fecha_desde, 102), 
									CONVERT(varchar,@hora_desde, 108), 
									@nombre, 
									@apellido, 
									@especialidad 
									)

							--Aumento 30 Minutos
							SET @hora_desde = DATEADD(MINUTE, 30, @hora_desde)
						END
					
					
						--Quito Horarios ya Tomados por Turnos
						DELETE
						FROM	@retorno
						-- Debo convertir sino no me deja comparar con el IN
						WHERE	horario_disponible  IN	(
														SELECT	CONVERT(varchar,hora, 108) AS hora_ocupada
														FROM	KFC.turnos t
																INNER JOIN KFC.profesionales p
																ON t.prof_id = p.prof_id
																INNER JOIN KFC.especialidades e
																ON t.espe_id = e.espe_id
														-- Debo convertir para solo comparar la fecha, no la hora incluida
														WHERE	CONVERT(DATE,fecha_hora) = CONVERT(DATE,@fecha_desde)
														AND		p.nombre         LIKE '%' + UPPER(@nombre)		+ '%'
														AND		p.apellido       LIKE '%' + UPPER(@apellido)	+ '%'		
														AND		UPPER(e.descripcion)	LIKE '%' + UPPER(@especialidad)		+ '%'
														)
					END
					--Sino, no inserta nada

					
					--Aumento 1 semana
					SET @fecha_desde = DATEADD(DAY, 7, @fecha_desde)
					--PRINT 'Aumento Semana'

			END

			--Traigo Siguiente Rango de Fechas
			FETCH NEXT FROM rango_fechas_horarios INTO @fecha_desde, @fecha_hasta, @dia, @hora_desde, @hora_hasta, @nombre, @apellido, @especialidad
	END
	
		
	CLOSE rango_fechas_horarios
	DEALLOCATE rango_fechas_horarios
	
	RETURN	
END;
GO

--Select * from KFC.fun_obtener_turnos_profesional( '','', '', '2016.01.01' );
--Select * from KFC.fun_obtener_turnos_profesional( '','', '', '2016.12.22' );
--Select * from KFC.fun_obtener_turnos_profesional( '','', '', '' );
--KFC.fun_obtener_turnos_profesional '','', '', '2016.12.22'
--KFC.fun_obtener_turnos_profesional '','', '', ''

------------------ASIGNAR_TURNO------------------
--Proposito: Asigna un Turno al Usuario y Profesional para una especialidad
--
--Ingreso: Datos necesarios para Crear un Nuevo Turno
------------------ASIGNAR_TURNO------------------
CREATE PROCEDURE KFC.pro_asignar_turno
          @fecha DATETIME
		, @hora	   VARCHAR(60)	--Hora del Turno, en Formato Varchar Para evitar problemas
		, @afil_id    INT
		, @espe_desc  VARCHAR(60)
		, @prof_nombre VARCHAR(60) 
		, @prof_apellido VARCHAR(60)
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @horaConvertida TIME(0);
				DECLARE @espe_id INT;
				DECLARE @prof_id INT;

				SET @horaConvertida = CONVERT(TIME(0),@hora, 108);

				SET @espe_id = KFC.fun_obtener_id_especialidad(@espe_desc);
				SET @prof_id = KFC.fun_obtener_id_profesional(@prof_nombre, @prof_apellido)


				INSERT INTO KFC.turnos(fecha_hora,hora,afil_id,espe_id,prof_id) VALUES (@fecha + CAST(@horaConvertida as DATETIME), @horaConvertida, @afil_id, @espe_id, @prof_id)
			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

					PRINT 'Turno No Ingresado. Fecha ' + CONVERT(varchar,@fecha,102)
                    ;THROW
        END CATCH
    END;
GO

------------------CANCELAR_TURNO------------------
--Proposito: Cancelar el turno de un afiliado
--
--Ingreso: datos necesarios para cancelar un turno
------------------CANCELAR_TURNO------------------
CREATE PROCEDURE KFC.pro_cancelar_turno
          @fecha DATETIME
		, @hora	   VARCHAR(60)
		, @espe_desc  VARCHAR(60)
		, @prof_nombre VARCHAR(60) 
		, @prof_apellido VARCHAR(60)
		, @tipo VARCHAR(15)
		, @motivo VARCHAR(255)
		, @fecha_formato_string VARCHAR(30)
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @horaConvertida TIME(0);
				DECLARE @espe_id INT;
				DECLARE @prof_id INT;
				DECLARE @turno_id INT;
				DECLARE @fecha_actual DATETIME;
				SET @fecha_actual = CONVERT(DATETIME, @fecha_formato_string, 102);

				SET @horaConvertida = CONVERT(TIME(0),@hora, 108);
				SET @espe_id = KFC.fun_obtener_id_especialidad(@espe_desc);
				SET @prof_id = KFC.fun_obtener_id_profesional(@prof_nombre, @prof_apellido)
				SET @turno_id = (
								SELECT turno_id FROM KFC.turnos 
								WHERE espe_id = @espe_id 
								AND prof_id = @prof_id 
								
								--Convierto asi Solo comparamos Fecha y Hora Separados
								AND CONVERT(DATE, fecha_hora) = CONVERT(DATE, @fecha) 
								AND hora = @horaConvertida
								
				)

				IF(@turno_id IS NULL) RAISERROR('No encontro Turno',16,1)

				INSERT INTO KFC.cancelaciones
				SELECT @turno_id, @motivo, @fecha_actual, CASE WHEN @tipo = 'USUARIO' THEN 1 ELSE 2 END

				--Vuelvo restablecer Bono Consumido
				UPDATE KFC.bonos	SET consumido = 0
				WHERE bono_id IN	(
									SELECT	a.bono_id
									FROM	KFC.atenciones a
											INNER JOIN KFC.turnos t
											ON t.turno_id = a.turno_id
									WHERE	t.prof_id = @prof_id
									AND		@fecha = t.fecha_hora
									)

			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

					PRINT 'Turno no cancelado. Fecha ' + CONVERT(varchar,@fecha,102)
                    ;THROW
        END CATCH
    END;
GO

/*
DECLARE @fecha DATETIME
SET @fecha = CONVERT(DATETIME, '2016.01.08', 102)
EXEC KFC.pro_cancelar_turno @fecha, '10:00:00',  'ALERGOLOGÍA','LARA','GIMÉNEZ','Motivooo','USUARIO', '2015.01.01'
*/

CREATE PROCEDURE KFC.pro_cancelar_turno_profesional
          @fechaDesde DATETIME
        , @fechaHasta DATETIME
        , @motivo VARCHAR(255)
        , @prof_id INT
        , @fecha_formato_string VARCHAR(30)
AS
    BEGIN
    BEGIN TRY
      BEGIN TRANSACTION

        DECLARE @fecha_actual DATETIME,
            @fecha_temp DATETIME,
            @cursor_espe_id INT,
            @cursor_dia INT,
            @cursor_fecha_desde DATETIME,
            @cursor_fecha_hasta DATETIME,
            @cursor_hora_desde TIME(0),
            @cursor_hora_hasta TIME(0);

        SET @fecha_actual = CONVERT(DATETIME, @fecha_formato_string, 102);

        INSERT INTO KFC.cancelaciones
        SELECT T.turno_id, @motivo, @fecha_actual, 2
        FROM KFC.turnos T
        FULL OUTER JOIN 
          KFC.cancelaciones C
          ON C.turno_id = T.turno_id
        INNER JOIN
          KFC.profesionales P
          ON P.prof_id = T.prof_id
        WHERE P.prof_id = @prof_id
        AND T.fecha_hora BETWEEN @fechaDesde AND @fechaHasta
        AND (T.turno_id IS NULL OR C.turno_id IS NULL)

		/*
        IF @@ROWCOUNT = 0     
                    RAISERROR ('No hay turnos a cancelar',16,1);
					*/

        --Vuelvo restablecer Bonos Consumidos
        UPDATE KFC.bonos  SET consumido = 0
        WHERE bono_id IN  (
                  SELECT  a.bono_id
                  FROM  KFC.atenciones a
                      INNER JOIN KFC.turnos t
                      ON t.turno_id = a.turno_id
                  WHERE t.prof_id = @prof_id
                  AND   CONVERT(date, @fechaDesde) >= CONVERT(date, t.fecha_hora)
                  AND   CONVERT(date, @fechaHasta) <= CONVERT(date, t.fecha_hora)
                  )

        DECLARE agenda CURSOR FOR   
        SELECT espe_id, dia, fecha_desde, fecha_hasta, hora_desde, hora_hasta FROM KFC.agenda WHERE prof_id = @prof_id AND DATEDIFF(day, @fechaDesde, fecha_hasta) >= 1

        OPEN agenda  
          FETCH NEXT FROM agenda
        INTO @cursor_espe_id, @cursor_dia, @cursor_fecha_desde, @cursor_fecha_hasta, @cursor_hora_desde, @cursor_hora_hasta

        WHILE @@FETCH_STATUS = 0  
        BEGIN 
          --- Caso :    CancelDesde----AgendaDesde-----CancelHasta-----AgendaHasta
          IF CONVERT(date, @cursor_fecha_desde) >= CONVERT(date, @fechaDesde) AND CONVERT(date, @cursor_fecha_hasta) > CONVERT(date, @fechaHasta)
            AND CONVERT(date, @fechaHasta) > CONVERT(date, @cursor_fecha_desde)
            BEGIN 
              UPDATE KFC.agenda SET fecha_desde = @fechaHasta + CAST(hora_desde as DATETIME)
              WHERE prof_id = @prof_id AND espe_id = @cursor_espe_id AND fecha_desde = @cursor_fecha_desde AND fecha_hasta = @cursor_fecha_hasta
              AND dia = @cursor_dia
            END
          --- Caso :    AgendaDesde----CancelDesde-----AgendaHasta-----CancelHasta
          ELSE IF CONVERT(date, @cursor_fecha_desde) < CONVERT(date, @fechaDesde) AND CONVERT(date, @cursor_fecha_hasta) <= CONVERT(date, @fechaHasta)
            AND CONVERT(date, @fechaDesde) < CONVERT(date, @cursor_fecha_hasta)
            BEGIN
              UPDATE KFC.agenda SET fecha_hasta = @fechaDesde + CAST(hora_hasta as DATETIME)
              WHERE prof_id = @prof_id AND espe_id = @cursor_espe_id AND fecha_desde = @cursor_fecha_desde AND fecha_hasta = @cursor_fecha_hasta
              AND dia = @cursor_dia
            END
          --- Caso :    AgendaDesde----CancelDesde-----CancelHasta-----AgendaHasta
          ELSE IF CONVERT(date, @cursor_fecha_desde) < CONVERT(date, @fechaDesde) AND CONVERT(date, @cursor_fecha_hasta) > CONVERT(date, @fechaHasta)
            BEGIN
              UPDATE KFC.agenda SET fecha_hasta = DATEADD(day, -1, @fechaDesde + CAST(hora_hasta as DATETIME))
              WHERE prof_id = @prof_id AND espe_id = @cursor_espe_id AND fecha_desde = @cursor_fecha_desde AND fecha_hasta = @cursor_fecha_hasta
              AND dia = @cursor_dia

              INSERT INTO KFC.agenda(espe_id, prof_id, dia, fecha_desde, fecha_hasta, hora_desde, hora_hasta)
              VALUES(@cursor_espe_id, @prof_id, @cursor_dia, @fechaHasta + CAST(@cursor_hora_desde as DATETIME), @cursor_fecha_hasta, @cursor_hora_desde, @cursor_hora_hasta)
            END
          --- Caso :    CancelDesde----AgendaDesde-----AgendaHasta-----CancelHasta
          ELSE IF (CONVERT(date, @cursor_fecha_desde) > CONVERT(date, @fechaDesde) AND CONVERT(date, @cursor_fecha_hasta) < CONVERT(date, @fechaHasta))
            OR (CONVERT(date, @cursor_fecha_desde) = CONVERT(date, @fechaDesde) AND CONVERT(date, @cursor_fecha_hasta) = CONVERT(date, @fechaHasta))
            BEGIN
              DELETE FROM KFC.agenda
              WHERE prof_id = @prof_id AND espe_id = @cursor_espe_id AND fecha_desde = @cursor_fecha_desde AND fecha_hasta = @cursor_fecha_hasta
              AND dia = @cursor_dia
            END

          FETCH NEXT FROM agenda
          INTO @cursor_espe_id, @cursor_dia, @cursor_fecha_desde, @cursor_fecha_hasta, @cursor_hora_desde, @cursor_hora_hasta
        END

        CLOSE agenda
        DEALLOCATE agenda

      COMMIT;
    END TRY
    BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

          PRINT 'Turnos no cancelados. Fechas ' + CONVERT(varchar,@fechaDesde,102) + ' - ' + CONVERT(varchar,@fechaHasta,102)
                    ;THROW
        END CATCH
    END;
GO

------------------OBTENER TURNOS CANCELABLES------------------
--Proposito: Busca los turnos de un afiliado que todavía pueden ser canceladas
--
--Ingreso: El ID del afiliado
------------------OBTENER TURNOS CANCELABLES------------------
CREATE FUNCTION kfc.fun_obtener_turnos_cancelables( @afil_id INT, @fecha_formato_string VARCHAR(30))
RETURNS TABLE AS
RETURN
SELECT
        CONCAT(P.apellido,', ', P.nombre)                                  profesional
        , CONCAT(DAY(T.fecha_hora), '/', MONTH(T.fecha_hora), '/', YEAR(T.fecha_hora)) fecha
        , T.hora                                                                       hora
        , E.descripcion
FROM
	KFC.turnos T
FULL OUTER JOIN 
	KFC.cancelaciones C
          ON
                    C.turno_id = T.turno_id
INNER JOIN
	KFC.profesionales P
          ON
                    P.prof_id = T.prof_id
INNER JOIN
	KFC.especialidades E
          ON
                    E.espe_id = T.espe_id
WHERE
          T.afil_id = @afil_id
          AND
          (
                    T.turno_id    IS NULL
                    OR C.turno_id IS NULL
          )
          AND DATEDIFF(DAY, CONVERT(DATETIME, @fecha_formato_string, 102), t.fecha_hora) >= 1
;
GO


CREATE FUNCTION kfc.fun_obtener_rango_agenda(@prof_id INT)
RETURNS DATETIME AS
BEGIN
	DECLARE @fecha_maxima DATETIME

	SELECT @fecha_maxima = MAX(fecha_hasta)
	FROM KFC.agenda
	WHERE prof_id = @prof_id

	RETURN @fecha_maxima
END
GO

CREATE PROCEDURE kfc.pro_crear_agenda_profesional
          @especialidad VARCHAR(255)
          ,
          @prof_id INT
          ,
          @dia INT
          ,
          @fecha_desde DATETIME
          ,
          @fecha_hasta DATETIME
AS
          BEGIN
	BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO KFC.agenda
                              (
                                        espe_id
                                      , prof_id
                                      , dia
                                      , fecha_desde
                                      , fecha_hasta
                                      , hora_desde
                                      , hora_hasta
                              )
                              VALUES
                              (
                                        KFC.fun_obtener_id_especialidad(@especialidad)
                                      , @prof_id
                                      , @dia
                                      , @fecha_desde
                                      , @fecha_hasta
                                      , CONVERT(TIME(0), @fecha_desde)
                                      , CONVERT(TIME(0), @fecha_hasta)
                              )
                    ;
                    
                    COMMIT;
	END TRY
	BEGIN CATCH
		IF @@trancount > 0
		ROLLBACK TRANSACTION;
		;THROW
	END CATCH
          END;
GO

--EXECUTE PROC kfc.pro_crear_agenda_profesional 'ALERGOLOGÍA', 6, 1, 


PRINT 'CREADAS FUNCIONES Y PROCEDURES DE NEGOCIO'
PRINT 'CREANDO FUNCIONES Y PROCEDURES PARA ESTADISTICAS...'
GO

CREATE PROCEDURE KFC.pro_top_5_cancelaciones_especialidad
          @año INT, @plazo_init INT, @plazo_fin INT, @cancelador INT
AS
BEGIN
          SELECT DISTINCT TOP 5 ESP.ESPE_ID id
                  , esp.descripcion
                  , ISNULL(COUNT(*),0) cancelaciones
          FROM
                    kfc.turnos tu
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.cancelaciones c
                                        WHERE
                                                  (
                                                            @año                             = 0
                                                            OR DATEPART(YEAR,c.fecha_cancel) = @año
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                        = 0
                                                            OR DATEPART(MONTH,c.fecha_cancel) >= @plazo_init
                                                  )
                                                  AND
                                                  (
                                                            @plazo_fin                         = 0
                                                            OR DATEPART(MONTH,c.fecha_cancel) <= @plazo_fin
                                                  )
                                                  AND
                                                  (
                                                            @cancelador         =0
                                                            OR c.tipo_cancel_id = @cancelador
                                                  ) ) ca
                    ON
                              tu.turno_id = ca.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
          GROUP BY
                    esp.espe_id
                  , esp.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO

------------------------------------------------------------
------------------------------------------------------------
CREATE PROCEDURE KFC.pro_top_5_profesional_popular
          @año INT, @plazo_init INT, @plazo_fin INT, @plan_id INT AS
BEGIN
          SELECT DISTINCT TOP 5--   PRO.PROF_ID,
                               concat(pro.apellido,', ', pro.nombre) profesional
                    --, esp.espe_id                           especialidad
                  , esp.descripcion
                  , ISNULL(COUNT(*),0) turnos
          FROM
                    (
                              SELECT
                                        *
                              FROM
                                        kfc.turnos t
                              WHERE
                                        (
                                                  @año                           =0
                                                  OR DATEPART(YEAR,t.fecha_hora) = @año
                                        )
                                        AND
                                        (
                                                  @plazo_init                      = 0
                                                  OR DATEPART(MONTH,t.fecha_hora) >= @plazo_init
                                        )
                                        AND
                                        (
                                                  @plazo_fin                       =0
                                                  OR DATEPART(MONTH,t.fecha_hora) <= @plazo_fin
                                        ) )tu
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
                    INNER JOIN
                              kfc.profesionales pro
                    ON
                              pro.prof_id = tu.prof_id
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.afiliados a
                                        WHERE
                                                  (
                                                            @plan_id    = 0
                                                            OR @plan_id = a.plan_id
                                                  ) )afi
                    ON
                              afi.afil_id = tu.afil_id
          GROUP BY
                    pro.prof_id
                  , concat(pro.apellido,', ', pro.nombre)
                  , esp.espe_id
                  , esp.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO
-------------------------------------------------------
-------------------------------------------------------

CREATE PROCEDURE KFC.pro_top_5_compradores_bonos
          @año INT, @plazo_init INT, @plazo_fin INT AS
BEGIN
          SELECT DISTINCT TOP 5 CONCAT(afi.apellido,', ', afi.nombre) 'Afiliado'
                  , 
					CASE 
						WHEN ISNULL(afi.personas_a_car,0) >0  THEN 'Si'                     
						ELSE 'No'
					END
					AS 'Tiene Grupo Familiar'
                  , ISNULL(COUNT(*),0)                                'Bonos Comprados'
          FROM-- Todos los afiliados con bonos
                    kfc.afiliados afi
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.bonos bo
                                        WHERE
                                                  (
                                                            @año                              =0
                                                            OR DATEPART(YEAR,bo.fecha_compra) = @año
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                         =0
                                                            OR DATEPART(MONTH,bo.fecha_compra) >= @plazo_init
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                         =0
                                                            OR DATEPART(MONTH,bo.fecha_compra) <= @plazo_fin
                                                  ) ) b --Bonos del Período elegido
                    ON
                              afi.afil_id = b.afil_id
          GROUP BY--Afiliado
                    b.afil_id
                  , ISNULL(afi.personas_a_car,0)
                  , afi.apellido
                  , afi.nombre
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO
----------------------------------------------------------------------------
----------------------------------------------------------------------------

CREATE PROCEDURE KFC.pro_top_5_espec_Atenciones
          @año INT, @plazo_init INT, @plazo_fin INT
AS
BEGIN
          SELECT DISTINCT TOP 5 esp.espe_id especialidad_id
                  , esp.descripcion
                  , ISNULL(COUNT(*),0) cantidad_bonos
          FROM
                    (
                              SELECT
                                        *
                              FROM
                                        kfc.turnos t
                              WHERE
                                        (
                                                  @año                           = 0
                                                  OR DATEPART(YEAR,t.fecha_hora) = @año
                                        )
                                        AND
                                        (
                                                  @plazo_init                      = 0
                                                  OR DATEPART(MONTH,t.fecha_hora) >= @plazo_init
                                        )
                                        AND
                                        (
                                                  @plazo_fin                       = 0
                                                  OR DATEPART(MONTH,t.fecha_hora) <= @plazo_fin
                                        ) ) tu
                    INNER JOIN
                              kfc.atenciones at
                    ON
                              tu.turno_id = at.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
          GROUP BY
                    esp.espe_id
                  , esp.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO
---------------------------------------------------------------------

CREATE PROCEDURE KFC.pro_top_5_prof_menos_trabajo
          @año INT, @plazo_init INT, @plazo_fin INT, @plan_id INT, @esp_id INT
AS
BEGIN
          SELECT DISTINCT TOP 5 CONCAT(pro.apellido,', ', pro.nombre) profesional
                  , esp.descripcion                                   especialidad
                  , pl.descripcion                                    nombre_plan
                  , ISNULL(COUNT(*),0)/4                              hs_trabajadas
                    --SUM(tu.duracion)
          FROM
                    (
                              SELECT
                                        *
                              FROM
                                        kfc.bonos bo
                              WHERE
                                        @plan_id = 0
                                        OR bo.plan_id  = @plan_id ) b
                    INNER JOIN
                              kfc.atenciones at
                    ON
                              b.bono_id = at.bono_id
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.turnos t
                                        WHERE
                                                  (
                                                            @año                           =0
                                                            OR DATEPART(YEAR,t.fecha_hora) = @año
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                      = 0
                                                            OR DATEPART(MONTH,t.fecha_hora) >= @plazo_init
                                                  )
                                                  AND
                                                  (
                                                            @plazo_fin                       =0
                                                            OR DATEPART(MONTH,t.fecha_hora) <= @plazo_fin
                                                  )
                                                  AND
                                                  (
                                                            @esp_id    = 0
                                                            OR @esp_id = t.espe_id
                                                  ) )tu
                    ON
                              tu.turno_id = at.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
                    INNER JOIN
                              kfc.profesionales pro
                    ON
                              pro.prof_id = tu.prof_id
                    INNER JOIN
                              kfc.planes pl
                    ON
                              b.plan_id = pl.plan_id
          GROUP BY
                    pro.prof_id
                  , pro.nombre
                  , pro.apellido
                  , b.plan_id
                  , esp.descripcion
                  , pl.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0)/4 ASC
          ;

END;
GO

CREATE PROCEDURE KFC.get_cmb_especialidades
AS
BEGIN
	SELECT e.espe_id id,  e.descripcion
	FROM KFC.especialidades e;
END;
GO

PRINT 'CREADAS FUNCIONES Y PROCEDURES PARA ESTADISTICAS'
GO















































----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'Creando Funciones y Procedures Deploy...'
GO

CREATE FUNCTION kfc.get_especialidades(@id_profesional INT)
returns TABLE
RETURN
SELECT
          esp.espe_id as id
        , esp.descripcion as descripcion 
		FROM
          kfc.especialidades esp
          
;
GO

CREATE PROCEDURE kfc.get_cmb_prof_x_esp (@id_esp INT)
as
SELECT
          prof.prof_id as id
        , concat(prof.apellido,', ',prof.nombre) AS descripcion
FROM
          kfc.especialidades_profesional ep
          INNER JOIN
                    kfc.profesionales prof
          ON
                    ep.prof_id= prof.prof_id
WHERE
          (
                    @id_esp       = 0
                    OR ep.espe_id = @id_esp
          )
;
GO

CREATE PROCEDURE kfc.get_turno_hoy (@afiliado_id INT,
@especialidad INT,
@profesional  INT,
@fecha		  DateTime)
AS
          SELECT	t.turno_id						   AS id
                  , CONCAT(a.apellido, ', ', a.nombre, ': ', esp.descripcion ) AS descripcion
          FROM
                    KFC.turnos t
                    INNER JOIN
                              kfc.afiliados a
                    ON
                              t.afil_id = a.afil_id
                    INNER JOIN
                              kfc.profesionales pr
                    ON
                              pr.prof_id = t.prof_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = t.espe_id
          WHERE
                    (
                              @profesional = 0
                              OR t.prof_id = @profesional
                    )
                    AND
                    (
                              @especialidad = 0
                              OR t.espe_id  = @especialidad
                    )
					AND
                    (
                              @afiliado_id = 0
                              OR t.afil_id  = @afiliado_id
                    )
                    AND (
		  DATEPART(YEAR, t.fecha_hora) = DATEPART(Year, @fecha) 
	           AND DATEPART(DAYOFYEAR, t.fecha_hora) =DATEPART(DAYOFYEAR, @fecha)
	           AND t.fecha_hora >= @fecha 
						   );
GO
/* Deprecated
CREATE PROCEDURE kfc.get_bonos_afiliado(@afiliado_id INT, @plan_id INT)
as
	SELECT
                    b.bono_id as id
                  , CONVERT(varchar(10), b.bono_id) as descripcion
          FROM
                    kfc.bonos b
          WHERE
                    b.afil_id       = @afiliado_id
					AND	b.plan_id = @plan_id
                    AND b.consumido = 0;
GO
*/

CREATE Procedure KFC.get_cmb_planes_sociales
as
SELECT pl.plan_id id, pl.descripcion FROM kfc.planes pl;
go

CREATE PROCEDURE KFC.registrar_llegada (@id_afiliado int, @id_turno int, @id_bono int, @hora time, @fecha Datetime)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			DECLARE @fecha_sumada DATETIME
			SET @fecha_sumada = @fecha + CONVERT(DATETIME, @hora)

			insert into kfc.atenciones(turno_id, hora_llegada, bono_id)
			values
			(@id_turno, @fecha_sumada, @id_bono);

			update kfc.bonos
			set consumido = 1
			where bono_id = @id_bono;

		COMMIT;
	END TRY
	BEGIN CATCH
		IF @@trancount > 0
        ROLLBACK TRANSACTION;
		PRINT 'LLegada Turno No Ingresada'
		;THROW
	END CATCH
END;
GO

CREATE PROCEDURE KFC.pro_registrar_atencion (@turno_id INT, @diagnostico VARCHAR(255), @sintomas VARCHAR(255), @fecha Datetime)
AS
BEGIN
  BEGIN TRY
    BEGIN TRANSACTION
      UPDATE KFC.atenciones SET sintomas = @sintomas, diagnostico = @diagnostico, hora_atencion = @fecha
      WHERE turno_id = @turno_id;
    COMMIT;
  END TRY
  BEGIN CATCH
    IF @@trancount > 0
        ROLLBACK TRANSACTION;
    PRINT 'La atencion no se registro correctamente'
    ;THROW
  END CATCH
END;
GO


CREATE PROCEDURE KFC.alta_afiliado( @nombre VARCHAR(255),
@apellido                                   VARCHAR(255),
@tipo_doc                                   VARCHAR(25),
@nro_doc                                    NUMERIC(18,0),
@direccion                                  VARCHAR(255),
@telefono                                   NUMERIC(18,0),
@mail                                       VARCHAR(255),
@sexo                                       CHAR(1),
@fecha_nac                                  DATETIME,
@estado                                     INT,
@plan                                       INT,
@usuario                                    INT,
@afil_id                                    NUMERIC(18,0) OUTPUT )
AS
          BEGIN
                    SET @afil_id = -1;
                    BEGIN TRY
                              BEGIN TRANSACTION
                              BEGIN

							  IF EXISTS( SELECT 1 FROM KFC.afiliados a WHERE a.nombre=@nombre AND a.apellido=@apellido AND a.numero_doc=@nro_doc ) RAISERROR('Ya existe el Afiliado',16,1);


							  --Insercion del usuario
                                        INSERT INTO kfc.usuarios
                                                  (
                                                            nick
                                                          , pass
                                                          , habilitado
                                                          , intentos
                                                  )
                                                  VALUES
                                                  (
                                                            @mail
                                                          , HASHBYTES('SHA2_256',@mail), 1, 0
                                                  )
                                        ;
                                        
                              SELECT @usuario = @@IDENTITY
                              END;

							  --Veo Ultimo Ingresado
							  DECLARE @max_user INT
								SELECT TOP 1 @max_user=a.afil_id
								FROM	KFC.afiliados a
								ORDER BY a.afil_id DESC

							  --Insercion Afiliado, si es el ultimo afiliado fue titular
							  if(
									KFC.obtener_titular(@max_user)=@max_user
								)
							  BEGIN
								--Inserto normal
								  INSERT INTO kfc.afiliados
											(
													  nombre
													, apellido
													, tipo_doc
													, numero_doc
													, direccion
													, telefono
													, mail
													, sexo
													, fecha_nacimiento
													, estado_id
													, plan_id
													, us_id
													, habilitado
											)
											VALUES
											(
													  @nombre
													, @apellido
													, @tipo_doc
													, @nro_doc
													, @direccion
													, @telefono
													, @mail
													, @sexo
													, @fecha_nac
													, @estado
													, @plan
													, @usuario
													, 1
											)
								  ;
							  END
							  --Sino, hay que insertar con 1
							  ELSE
							  BEGIN
								SET IDENTITY_INSERT KFC.afiliados ON;
								INSERT INTO kfc.afiliados
											(
													afil_id
													, nombre
													, apellido
													, tipo_doc
													, numero_doc
													, direccion
													, telefono
													, mail
													, sexo
													, fecha_nacimiento
													, estado_id
													, plan_id
													, us_id
													, habilitado
											)
											VALUES
											(
													(floor(@max_user/100)+1)*100 + 1
													,  @nombre
													, @apellido
													, @tipo_doc
													, @nro_doc
													, @direccion
													, @telefono
													, @mail
													, @sexo
													, @fecha_nac
													, @estado
													, @plan
													, @usuario
													, 1
											)
								  ;
								SET IDENTITY_INSERT KFC.afiliados OFF;
							  END
                              
                              SELECT @afil_id = @@IDENTITY;
                              
                              --Inserto Rol al usuario Creado para poder Loguearse
                              INSERT INTO KFC.roles_usuarios
                                        (
                                                  us_id
                                                , rol_id
                                        )
                              SELECT DISTINCT a.us_id
                                      , ru.rol_id
                              FROM
                                        KFC.roles_usuarios ru
                                        INNER JOIN
                                                  KFC.roles r
                                        ON
                                                  r.rol_id = ru.rol_id
                                                , KFC.afiliados a
                              WHERE
                                        UPPER(r.descripcion) = 'AFILIADO'
                                        AND a.us_id          = @usuario
                              COMMIT;
                              RETURN
                    END TRY
                    BEGIN CATCH
                              IF @@trancount > 0
                              ROLLBACK TRANSACTION;
                              PRINT 'Afiliado No Ingresado.';
                              THROW
                    END CATCH
          END;
GO


CREATE PROCEDURE KFC.alta_afiliado_adjunto ( @nombre VARCHAR(255),
@apellido                                            VARCHAR(255),
@tipo_doc                                            VARCHAR(25),
@nro_doc                                             NUMERIC(18,0),
@direccion                                           VARCHAR(255),
@telefono                                            NUMERIC(18,0),
@mail                                                VARCHAR(255),
@sexo                                                CHAR(1),
@fecha_nac                                           DATETIME,
@estado                                              INT,
@plan                                                INT,
@afil_id_titular                                     INT,
@conyuge											 INT,
@afil_id                                             NUMERIC(18,0) OUTPUT)
AS
BEGIN
          DECLARE @id      INT;
          DECLARE @usuario INT;
          
                    IF EXISTS( SELECT 1 FROM KFC.afiliados a WHERE a.nombre=@nombre AND a.apellido=@apellido AND a.numero_doc=@nro_doc ) RAISERROR('Ya existe el Afiliado',16,1);
					
          BEGIN TRANSACTION
			    BEGIN TRY
				IF @conyuge > 0
				BEGIN
					select @id = @afil_id_titular+1;
				END
				ELSE
				BEGIN
                    --Calculo ID de Afiliado No Titular
					SELECT
                              @id= MAX(af.afil_id) +1
                    FROM
                              kfc.afiliados af
                    WHERE
                              Floor(af.afil_id/100) = Floor(@afil_id_titular/100);

					IF @id = @afil_id_titular+1
					BEGIN
						select @id = @afil_id_titular+2;
					END
				END

					--Insercion del usuario
                                        INSERT INTO kfc.usuarios
                                                  (
                                                            nick
                                                          , pass
                                                          , habilitado
                                                          , intentos
                                                  )
                                                  VALUES
                                                  (
                                                            @mail
                                                          , HASHBYTES('SHA2_256',@mail), 1, 0
                                                  );
                                        
                              SELECT @usuario = @@IDENTITY

					 --Insercion Afiliado
                    SET IDENTITY_INSERT KFC.afiliados ON
                    
   
                              INSERT INTO KFC.afiliados
                                        (
                                                  afil_id
                                                , nombre
                                                , apellido
                                                , tipo_doc
                                                , numero_doc
                                                , direccion
                                                , telefono
                                                , mail
                                                , sexo
                                                , fecha_nacimiento
                                                , estado_id
                                                , plan_id
                                                , us_id
                                                , habilitado
                                        )
                                        VALUES
                                        (
                                                  @id
                                                , @nombre
                                                , @apellido
                                                , @tipo_doc
                                                , @nro_doc
                                                , @direccion
                                                , @telefono
                                                , @mail
                                                , @sexo
                                                , @fecha_nac
                                                , @estado
                                                , @plan
                                                , @usuario
                                                , 1
                                        )
                              ;
                              
                              SELECT @afil_id = @id;
                              
                              SET IDENTITY_INSERT KFC.afiliados OFF;
							  
							  --Actualizo afiliadoTitular personas a cargo
                              UPDATE
                                        kfc.afiliados
                              SET       personas_a_car = ISNULL(personas_a_car,0)+1
                              WHERE
                                        afil_id = @afil_id_titular
                              ;

							  --Inserto Rol al usuario Creado para poder Loguearse
                              INSERT INTO KFC.roles_usuarios
                                        (        us_id
                                                , rol_id
                                        )
                              SELECT DISTINCT a.us_id
                                      , ru.rol_id
                              FROM
                                        KFC.roles_usuarios ru
                                        INNER JOIN
                                                  KFC.roles r
                                        ON
                                                  r.rol_id = ru.rol_id
                                                , KFC.afiliados a
                              WHERE
                                        UPPER(r.descripcion) = 'AFILIADO'
                                        AND a.us_id          = @usuario
                              
                              COMMIT;
                    END TRY
                    BEGIN CATCH
                              ROLLBACK;
                              THROW;
                    END CATCH
          END;
GO


CREATE PROCEDURE KFC.get_afiliado( @id_afiliado INT)
AS
          SELECT * FROM kfc.afiliados a WHERE a.afil_id = @id_afiliado;

GO

CREATE PROCEDURE KFC.get_cmb_estado_civil
AS
          SELECT DISTINCT c.estado_id , c.descripcion FROM kfc.estado_civil c;

GO

CREATE PROCEDURE KFC.modifica_afiliado( 
								 @afiliado int,
								 @tipo_doc varchar(25),
								 @direccion varchar(255),
								 @telefono numeric(18,0),
								 @mail  varchar(255),
								 @sexo char(1),
								 @estado int,
								 @plan int,
								 @fecha VARCHAR(30) 
								 )
as
DECLARE @fecha_formateada datetime;
DECLARE @plan_anterior int;
Begin
		BEGIN TRY
			BEGIN TRANSACTION
			SET @fecha_formateada = CONVERT(DATETIME, @fecha, 102);
			select @plan_anterior= afi.plan_id from afiliados afi where afi.afil_id = @afiliado and habilitado=1;
			IF (@plan_anterior <> @plan )
			insert into kfc.historial_afiliados(afil_id,plan_activo,fecha,motivo_cambio)
			values(@afiliado,@plan_anterior,@fecha_formateada,'El afiliado cambio su plan')

			Update kfc.afiliados
			set tipo_doc = @tipo_doc,
				direccion = @direccion,
				telefono = @telefono,
				mail = @mail,
				sexo = @sexo,
				estado_id = @estado,
				plan_id = @plan
				where afil_id = @afiliado;

			
			Commit;
			End try
			BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			THROW
			END CATCH
end;
go

	

CREATE PROCEDURE KFC.baja_afiliado( @afiliado INT, @fecha VARCHAR(30) )
AS
DECLARE @plan INT
DECLARE @fecha_formateada DATETIME
DECLARE @usuario INT
BEGIN
BEGIN TRY
	SET @fecha_formateada = CONVERT(DATETIME, @fecha, 102);
	BEGIN TRANSACTION
		--Deshabilito el afiliado
		UPDATE kfc.afiliados
		SET habilitado = 0,
			@plan = plan_id
		WHERE afil_id = @afiliado;
		
		--Selecciona el usuario del afiliado
		select @usuario = us_id from kfc.afiliados us where afil_id = @afiliado;

		--Quita la funcionalidad afiliado del usuario
		DELETE kfc.roles_usuarios
		WHERE us_id = @usuario
		AND rol_id = 1;
		
		--Elimino los turnos que tiene pedidos y que no usó
		DELETE FROM kfc.turnos 
		WHERE afil_id = @afiliado and YEAR(fecha_hora)>=YEAR(@fecha_formateada) 
		and DATEPART(DAYOFYEAR, fecha_hora)>DATEPART(DAYOFYEAR,@fecha_formateada) 
		and turno_id not in (
			--Que no elimine turnos cancelados
			SELECT ca.turno_id from kfc.cancelaciones ca
			inner join turnos tr on ca.turno_id = tr.turno_id
			where tr.afil_id = @afiliado
			AND YEAR(fecha_hora)>=YEAR(@fecha_formateada) 
			AND DATEPART(DAYOFYEAR, fecha_hora)>DATEPART(DAYOFYEAR,@fecha_formateada)
			UNION
		--Obtiene todas las atenciones de turnos a partir de este momento
		--(esto es por culpa de que la fecha no es la real)
			SELECT tu.turno_id from kfc.turnos tu
			  inner join kfc.atenciones ate on tu.turno_id = ate.turno_id
			  WHERE afil_id = @afiliado
			AND YEAR(fecha_hora)>=YEAR(@fecha_formateada) 
			AND DATEPART(DAYOFYEAR, fecha_hora)>DATEPART(DAYOFYEAR,@fecha_formateada
			)
);
	
	IF (floor(@afiliado/100)*100+1) = @afiliado
	EXECUTE	KFC.baja_grupo_afiliado @afiliado , @fecha_formateada;


	Insert Into kfc.historial_afiliados values(@afiliado, @fecha_formateada ,@plan,'El afiliado ha sido dado de baja');
	
COMMIT;
END TRY
BEGIN CATCH 
       IF @@trancount > 0
       ROLLBACK TRANSACTION;
       PRINT 'Afiliado No Eliminado.';
       THROW
END CATCH
END
GO

CREATE PROCEDURE KFC.baja_grupo_afiliado ( @afiliado INT, @fecha DATETIME)
AS
declare @interno int
BEGIN
	DECLARE adjuntos CURSOR FOR   
	--Selecciono todo el Grupo Familiar
	SELECT afil_id FROM afiliados WHERE floor(afil_id/100) = floor(@afiliado/100) and habilitado = 1  
	
	OPEN adjuntos  
  	FETCH NEXT FROM adjuntos
	INTO @interno

	WHILE @@FETCH_STATUS = 0  
	BEGIN 
		EXECUTE KFC.baja_afiliado @interno, @fecha
		FETCH NEXT FROM adjuntos
		INTO @interno
	END 

	CLOSE adjuntos
    DEALLOCATE adjuntos
END
go

PRINT 'Creadas Funciones y Procedures Deploy'
GO



















































----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'POBLANDO TABLAS...'

DECLARE @true BIT
SET @true = 1

-- Insercion Estados Civiles del Enunciado
PRINT '- Llenando Tabla estado_civil...'
INSERT INTO KFC.estado_civil(descripcion) VALUES ('SOLTERO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('CASADO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('VIUDO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('CONCUBINATO')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('DIVORCIADO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('NO ESPECIFICA')			--Para los Datos de la Tabla Maestra

-- Insercion Funcionalidades
PRINT '- Llenando Tabla funcionalidades...'
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('ALTA_AFILIADO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('MODIFICAR_AFILIADO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('BAJA_AFILIADO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('PEDIR_TURNO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CANCELAR_TURNO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('COMPRAR_BONO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CREAR_AGENDA')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CANCELAR_TURNOS_AGENDA')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('REGISTRAR_LLEGADA')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('REGISTRAR_DIAGNOSTICO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CREAR_ROL')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('MODIFICAR_ROL')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('COMPRA_BONO_ADMINISTRADOR')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('ESTADISTICAS')

-- Insercion Roles del Enunciado
PRINT '- Llenando Tabla roles...'
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('AFILIADO', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('PROFESIONAL', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('ADMINISTRATIVO', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('ADMINISTRADOR GENERAL', @true)

-- Insercion Funcionalidades por Roles
PRINT '- Llenando Tabla funcionalidades_roles...'
INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'AFILIADO'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion    = 'PEDIR_TURNO'
		OR F.descripcion = 'COMPRAR_BONO'
		OR F.descripcion = 'CANCELAR_TURNO'
		)

INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'PROFESIONAL'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion	 = 'CREAR_AGENDA'
		OR F.descripcion = 'CANCELAR_TURNOS_AGENDA'
		OR F.descripcion = 'REGISTRAR_DIAGNOSTICO'
		)

INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'ADMINISTRATIVO'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion	 = 'ALTA_AFILIADO'
		OR F.descripcion = 'MODIFICAR_AFILIADO'
		OR F.descripcion = 'BAJA_AFILIADO'
		OR F.descripcion = 'REGISTRAR_LLEGADA'
		OR F.descripcion = 'CREAR_ROL'
		OR F.descripcion = 'MODIFICAR_ROL'
		OR F.descripcion = 'COMPRA_BONO_ADMINISTRADOR'
		)

INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'ADMINISTRADOR GENERAL'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion	 = 'ALTA_AFILIADO'
		OR F.descripcion = 'MODIFICAR_AFILIADO'
		OR F.descripcion = 'BAJA_AFILIADO'
		OR F.descripcion = 'REGISTRAR_LLEGADA'
		OR F.descripcion = 'CREAR_ROL'
		OR F.descripcion = 'MODIFICAR_ROL'
		OR F.descripcion = 'COMPRA_BONO_ADMINISTRADOR'
		OR F.descripcion = 'ESTADISTICAS'
		)


-- Insercion Usuarios del Enunciado
PRINT '- Llenando Tabla usuarios...'
INSERT INTO KFC.usuarios(nick,pass,habilitado) VALUES ('ADMIN', HASHBYTES('SHA2_256','W23E'), @true)
INSERT INTO KFC.usuarios(nick,pass,habilitado) VALUES ('RECEPCION', HASHBYTES('SHA2_256','RECEPCION'), @true)

--Agrego Usuarios para Afiliados, pedido por el Enunciado
INSERT INTO KFC.usuarios
          (
			  nick 
			, pass 
			, habilitado
          )
SELECT DISTINCT  UPPER(Paciente_Mail)
        ,  HASHBYTES('SHA2_256',UPPER(Paciente_Mail)) AS pass
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Paciente_Mail IS NOT NULL


--Agrego Usuarios para Profesionales, pedido por el Enunciado
INSERT INTO KFC.usuarios
          (
			  nick 
			, pass 
			, habilitado
          )
SELECT DISTINCT  UPPER(Medico_Mail)
        ,  HASHBYTES('SHA2_256',UPPER(Medico_Mail)) AS pass
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Medico_Mail IS NOT NULL


-- Insercion Roles por Usuario
PRINT '- Llenando Tabla roles_usuarios...'
INSERT INTO KFC.roles_usuarios (us_id, rol_id)
SELECT
          u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
        UPPER(r.descripcion) =   UPPER('ADMINISTRATIVO')
        AND   UPPER(u.nick)    =   UPPER('RECEPCION')


INSERT INTO KFC.roles_usuarios (us_id, rol_id)
SELECT
          u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
        UPPER(r.descripcion) =   UPPER('ADMINISTRADOR GENERAL')
        AND   UPPER(u.nick)    =   UPPER('ADMIN')



-- Insercion Roles para Afiliados
INSERT INTO KFC.roles_usuarios
          (
			  us_id
			, rol_id
          )
SELECT DISTINCT
          u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
          UPPER(r.descripcion) = UPPER('AFILIADO')
		  -- Selecciono Solo los Afiliados
          AND u.nick IN (
							SELECT DISTINCT Paciente_Mail
							FROM
										GD2C2016.gd_esquema.Maestra
							WHERE
										Paciente_Mail IS NOT NULL
						)
ORDER BY  u.us_id


-- Insercion Roles para Profesionales
INSERT INTO KFC.roles_usuarios
          (
			  us_id
			, rol_id
          )
SELECT DISTINCT 
		  u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
          UPPER(r.descripcion) = UPPER('PROFESIONAL')
		  -- Selecciono Solo los Profesionales
          AND u.nick IN (
							SELECT DISTINCT Medico_Mail
							FROM
										GD2C2016.gd_esquema.Maestra
							WHERE
										Medico_Mail IS NOT NULL
						)
ORDER BY
          u.us_id



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Planes
-- El IDENTITY_INSERT me permite introducir manualmente claves donde seria autoincrementable
-- Link IDENTITY_INSERT: https://www.mssqltips.com/sqlservertutorial/2521/insert-into-sql-server-table-with-identity-column/
PRINT '- Llenando Tabla planes...'
SET IDENTITY_INSERT KFC.planes ON
INSERT INTO KFC.planes
          (
                    plan_id
                  , descripcion
                  , precio_bono_consulta
                  , precio_bono_farmacia
          )
SELECT DISTINCT Plan_Med_Codigo
        ,  UPPER(Plan_Med_Descripcion)
        , Plan_Med_Precio_Bono_Consulta
        , Plan_Med_Precio_Bono_Farmacia
FROM
          GD2C2016.gd_esquema.Maestra
ORDER BY
          Plan_Med_Codigo
SET IDENTITY_INSERT KFC.planes OFF


--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Afiliados
PRINT '- Llenando Tabla afiliados...'
SET IDENTITY_INSERT KFC.afiliados ON
INSERT INTO KFC.afiliados
          (
                    afil_id
				  , tipo_doc
                  , numero_doc
                  , nombre
                  , apellido
				  , sexo
                  , direccion
                  , telefono
                  , mail
                  , fecha_nacimiento
                  , plan_id
				  , us_id
				  , estado_id
                  , habilitado
          )
SELECT 
		ROW_NUMBER() OVER( ORDER BY us_id ) * 100 + 1				--Para generar los ID de Afiliados, todos titulares
		, 'DNI' AS Tipo_Doc
        , m.Paciente_Dni
        ,  UPPER(m.Paciente_Nombre) AS nombre
        ,  UPPER(m.Paciente_Apellido) AS apellido
		, 'P' AS sexo								-- P de Pendiente
        ,  UPPER(m.Paciente_Direccion) AS direccion
        , m.Paciente_Telefono
        ,  UPPER(m.Paciente_Mail) AS mail
        , m.Paciente_Fecha_Nac
        , m.Plan_Med_Codigo
		, u.us_id
		, e.estado_id
        , 1 AS habilitado
FROM
			--Es Necesario Subconsulta para evitar repetidos
          (
			  SELECT DISTINCT Paciente_Dni, Paciente_Nombre, Paciente_Apellido, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Plan_Med_Codigo
			  FROM GD2C2016.gd_esquema.Maestra
		  ) m
		  INNER JOIN KFC.usuarios u
		  ON m.Paciente_Mail = u.nick
		  INNER JOIN KFC.estado_civil e
		  ON e.descripcion = 'NO ESPECIFICA'
WHERE
			Paciente_Dni IS NOT NULL
ORDER BY
          u.us_id
SET IDENTITY_INSERT KFC.afiliados OFF


--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Profesionales
PRINT '- Llenando Tabla profesionales...'
INSERT INTO KFC.profesionales
          (
                    tipo_doc
                  , numero_doc
                  , nombre
                  , apellido
                  , direccion
                  , telefono
                  , mail
                  , fecha_nacimiento
				  , us_id
                  , habilitado
          )
SELECT DISTINCT 'DNI' AS Tipo_Doc
        , m.Medico_Dni
        ,  UPPER(m.Medico_Nombre)
        ,  UPPER(m.Medico_Apellido)
        ,  UPPER(m.Medico_Direccion)
        , m.Medico_Telefono
        ,  UPPER(m.Medico_Mail)
        , m.Medico_Fecha_Nac
		, u.us_id
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra m
		  , KFC.usuarios u
WHERE
          Medico_Dni IS NOT NULL
		  AND m.Medico_Mail = u.nick
ORDER BY
          u.us_id
 



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Tipos Especialidades
PRINT '- Llenando Tabla tipos_especialidades...'
SET IDENTITY_INSERT KFC.tipos_especialidades ON
INSERT INTO KFC.tipos_especialidades
          (
			tipo_esp_id
			, descripcion
          )
SELECT DISTINCT Tipo_Especialidad_Codigo
        ,  UPPER(Tipo_Especialidad_Descripcion)
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Tipo_Especialidad_Codigo IS NOT NULL
ORDER BY
          Tipo_Especialidad_Codigo
SET IDENTITY_INSERT KFC.tipos_especialidades OFF



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Especialidades
PRINT '- Llenando Tabla especialidades...'
SET IDENTITY_INSERT KFC.especialidades ON
INSERT INTO KFC.especialidades
          (
		      espe_id
			, descripcion
			, tipo_esp_id
          )
SELECT DISTINCT Especialidad_Codigo
        ,  UPPER(Especialidad_Descripcion)
        , Tipo_Especialidad_Codigo
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Especialidad_Codigo IS NOT NULL
ORDER BY
          Especialidad_Codigo
SET IDENTITY_INSERT KFC.especialidades OFF
 



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Especialidad Profesional
--El ID de profesional necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
PRINT '- Llenando Tabla especialidades_profesional...'
INSERT INTO KFC.especialidades_profesional
          (
		     espe_id
		   , prof_id
          )
SELECT DISTINCT 
		  m.Especialidad_Codigo
        , p.prof_id
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.profesionales           p
WHERE
          m.Especialidad_Codigo IS NOT NULL
          AND m.Medico_Nombre             = p.nombre
          AND m.Medico_Apellido           = p.apellido
          AND m.Medico_Dni                = p.numero_doc
ORDER BY
          m.Especialidad_Codigo
 



------------------------------------------------------------------
--Tomo Datos de Tabla Maestra y los Inserto en Tabla  la Agenda
--
--El ID de Profesional necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
--Este codigo es complicado, pero basicamente lo que hago es calcular los rangos de horarios usando funciones de sumarizacion
--No se preocupen tanto por las conversiones y calculos, las hace y funciona bien. Lo comprobe manualmente.
--Link CONVERT: https://msdn.microsoft.com/en-us/library/ms187928.aspx
------------------------------------------------------------------
PRINT '- Llenando Tabla agenda...'
INSERT INTO KFC.agenda
          (
                    espe_id
                  , prof_id
                  , dia
                  , fecha_desde
                  , fecha_hasta
                  , hora_desde
                  , hora_hasta
          )
SELECT DISTINCT 
		  m.Especialidad_Codigo
        , p.prof_id
        , DATEPART(WEEKDAY, m.Turno_Fecha)       AS dia_semana
        , MIN( m.Turno_Fecha )                   AS fecha_desde
        , MAX( m.Turno_Fecha )                   AS fecha_hasta
        , CONVERT( TIME(0), MIN( m.Turno_Fecha) ) AS hora_desde
        , CONVERT( TIME(0), MAX( m.Turno_Fecha) ) AS hora_hasta
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.profesionales           p
WHERE
          m.Especialidad_Codigo IS NOT NULL
          AND m.Turno_Fecha     IS NOT NULL
          AND m.Medico_Nombre             = p.nombre
          AND m.Medico_Apellido           = p.apellido
          AND m.Medico_Dni                = p.numero_doc
GROUP BY
          Especialidad_Codigo
        , p.prof_id
        , DATEPART(WEEKDAY, m.Turno_Fecha)

--Dato Extra Nuestro para Pruebas
PRINT '- Llenando Tabla agenda...'
INSERT INTO KFC.agenda
          (
                    espe_id
                  , prof_id
                  , dia
                  , fecha_desde
                  , fecha_hasta
                  , hora_desde
                  , hora_hasta
          )
SELECT DISTINCT 
		  e.espe_id
        , p.prof_id
        , DATEPART(WEEKDAY,  CONVERT( DATETIME, '2016.01.01', 102) )       AS dia_semana
        , CONVERT( DATETIME, '2016.01.01', 102)                   AS fecha_desde
        , CONVERT( DATETIME, '2016.01.30', 102)                   AS fecha_hasta
        , CONVERT(TIME(0), '10:00:00', 108) AS hora_desde
        , CONVERT(TIME(0), '12:00:00', 108) AS hora_hasta
FROM
          KFC.especialidades	e
        , KFC.profesionales     p
WHERE
          UPPER('ALERGOLOGÍA')	= UPPER(e.descripcion)
          AND	UPPER('LARA')		=  UPPER(p.nombre)
          AND	UPPER('GIMÉNEZ')		=  UPPER(p.apellido)



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Tipos Cancelaciones
PRINT '- Llenando Tabla tipos_cancelaciones...'
INSERT INTO KFC.tipos_cancelaciones	Values('Por Usuario')
INSERT INTO KFC.tipos_cancelaciones	Values('Por Medico')


--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Turnos
--El ID de profesional, especialidad y afiliado necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla. De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
PRINT '- Llenando Tabla turnos...'
SET IDENTITY_INSERT KFC.turnos ON
INSERT INTO KFC.turnos
          (
			    turno_id
			  , fecha_hora
			  , hora
			  , afil_id
			  , espe_id
			  , prof_id
          )
SELECT DISTINCT m.Turno_Numero
        , m.Turno_Fecha
        , CONVERT(TIME(0), m.Turno_Fecha) AS hora		--Covierto Formato Datos
        , a.afil_id
        , m.Especialidad_Codigo
        , p.prof_id
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.afiliados               a
        , KFC.profesionales           p
WHERE
          m.Turno_Numero IS NOT NULL
          AND m.Paciente_Nombre    = a.nombre
          AND m.Paciente_Apellido  = a.apellido
          AND m.Paciente_Dni       = a.numero_doc
          AND m.Medico_Nombre      = p.nombre
          AND m.Medico_Apellido    = p.apellido
          AND m.Medico_Dni         = p.numero_doc
ORDER BY
          m.Turno_Numero
SET IDENTITY_INSERT KFC.turnos OFF
 




--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Bonos
--El ID  de plan y afiliado necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
PRINT '- Llenando Tabla bonos...'
SET IDENTITY_INSERT KFC.bonos ON
INSERT INTO KFC.bonos
          (
			    bono_id
			  , afil_id
			  , plan_id
			  , fecha_compra
			  , fecha_impresion
          )
SELECT DISTINCT m.Bono_Consulta_Numero
        , a.afil_id
        , m.Plan_Med_Codigo
        , m.Compra_Bono_Fecha
        , m.Bono_Consulta_Fecha_Impresion
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.afiliados               a
WHERE
          m.Compra_Bono_Fecha        IS NOT NULL
          AND m.Bono_Consulta_Numero IS NOT NULL
          AND m.Paciente_Nombre                = a.nombre
          AND m.Paciente_Apellido              = a.apellido
          AND m.Paciente_Dni                   = a.numero_doc
ORDER BY
          m.Bono_Consulta_Numero
SET IDENTITY_INSERT KFC.bonos OFF





--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Atenciones
PRINT '- Llenando Tabla atenciones...'
INSERT INTO KFC.atenciones
          (
			    turno_id
			  , hora_llegada
			  , sintomas
			  , diagnostico
			  , bono_id
			  , hora_atencion
          )
SELECT DISTINCT Turno_Numero
        , Bono_Consulta_Fecha_Impresion --Considero la Fecha de la Impresion del Bono como la de la Atencion (unicamente para Turnos Migrados), Ya que consideramos que el Bono se Imprime al momento de su uso (en el sistema anterior)
        ,  UPPER(Consulta_Sintomas)
        ,  UPPER(Consulta_Enfermedades)
        , Bono_Consulta_Numero
		, Bono_Consulta_Fecha_Impresion	--Idem hora llegada
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Turno_Numero             IS NOT NULL
          AND Bono_Consulta_Numero IS NOT NULL
ORDER BY
          Turno_Numero
 

 ---Actualizo Bonos Consumidos
UPDATE KFC.bonos SET consumido = 1
WHERE  bono_id IN ( SELECT bono_id FROM KFC.atenciones  )



 PRINT 'TABLAS POBLADAS'

















































----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'CREANDO TRIGGERS...'
GO

-- Se chequea la integridad de los datos a insertar en la tabla FUNCIONALIDADES_ROLES
CREATE TRIGGER KFC.rol_nueva_funcionalidad
ON KFC.funcionalidades_roles
INSTEAD OF INSERT AS
	IF NOT EXISTS (SELECT * FROM KFC.roles WHERE rol_id = (SELECT rol_id FROM inserted))
	BEGIN
		RAISERROR ('No existe el rol a insertar en la tabla de relacion', 16, 1);
		RETURN
	END

	IF NOT EXISTS (SELECT * FROM KFC.funcionalidades WHERE func_id = (SELECT func_id FROM inserted))
		BEGIN
			RAISERROR ('No existe la funcionalidad a asociar en la tabla de relacion', 16, 1);
		RETURN
	END

	INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
	SELECT rol_id, func_id
	FROM inserted;

GO
---------------------------------------------------------------------------

-- Se chequea la integridad de los datos para habilitar/deshabilitar un rol --
CREATE TRIGGER KFC.existe_rol_habilitar_deshabilitar
ON KFC.roles
INSTEAD OF UPDATE AS
	IF NOT EXISTS (SELECT * FROM KFC.roles r, inserted i WHERE r.rol_id = i.rol_id )
	BEGIN
		RAISERROR ('No existe el rol a habilitar/deshabilitar', 16, 1);
		RETURN
	END

	UPDATE KFC.roles SET habilitado = i.habilitado
	FROM	KFC.roles r
		INNER JOIN	inserted i
		ON	r.rol_id = i.rol_id
GO
---------------------------------------------------------------------------

/*
-- Todavía no funciona - aclarar el tema del ID de los afiliados --
CREATE TRIGGER KFC.existe_afiliado_principal
ON KFC.afiliados
INSTEAD OF INSERT AS

DECLARE @afil_id int;
DECLARE @afil_id_base int;
SELECT @afil_id = afil_id FROM inserted;

IF @afil_id NOT LIKE '%01'
BEGIN
	SELECT @afil_id_base = @afil_id/100;
	IF EXISTS (SELECT * FROM KFC.afiliados WHERE afil_id = (@afil_id_base*100+1)
				AND personas_a_car IS NOT NULL)
		BEGIN TRANSACTION
			INSERT INTO KFC.afiliados
			SELECT * FROM inserted;
		COMMIT;
END
ELSE
BEGIN
	RAISERROR ('No existe el afiliado principal', 16, 1);
	RETURN
END;
GO
---------------------------------------------------------------------------
*/

-- Trigger para chequear el insert en la agenda --
CREATE TRIGGER KFC.nueva_agenda_profesional
ON KFC.agenda
INSTEAD OF INSERT AS
IF NOT EXISTS (SELECT * FROM KFC.profesionales 
	WHERE prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('No existe el profesional indicado', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades 
	WHERE espe_id = (SELECT espe_id FROM inserted))
	BEGIN
		RAISERROR ('No existe la especialidad indicada', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades_profesional 
	WHERE espe_id = (SELECT espe_id FROM inserted) AND prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('El profesional no tiene la especialidad indicada', 16, 1);
		RETURN
	END;
IF ((SELECT fecha_desde from inserted) > (SELECT fecha_hasta from inserted))
	BEGIN
		RAISERROR ('La fecha de inicio no puede ser mayor a la del final', 16, 1);
		RETURN
	END;
IF ((SELECT hora_desde from inserted) > (SELECT hora_hasta from inserted))
	BEGIN
		RAISERROR ('La hora de inicio no puede ser mayor a la del final', 16, 1);
		RETURN
	END;

	INSERT INTO KFC.agenda(espe_id, prof_id, dia, fecha_desde, fecha_hasta, hora_desde, hora_hasta)
	VALUES(
	 (SELECT espe_id FROM inserted), 
	 (SELECT prof_id FROM inserted), 
	 (SELECT dia FROM inserted), 
	 (SELECT fecha_desde FROM inserted), 
	 (SELECT fecha_hasta FROM inserted), 
	 (SELECT hora_desde FROM inserted), 
	 (SELECT hora_hasta FROM inserted)
	 );
GO
---------------------------------------------------------------------------

-- Trigger para chequear la informacion del bono --
CREATE TRIGGER KFC.nuevo_bono
ON KFC.bonos
INSTEAD OF INSERT AS
IF NOT EXISTS (SELECT * FROM KFC.afiliados a INNER JOIN inserted i ON a.afil_id = i.afil_id )
BEGIN
	RAISERROR ('No existe el afiliado que intenta comprar el bono', 16, 1);
	RETURN
END;
IF NOT EXISTS (SELECT * FROM KFC.planes p INNER JOIN inserted i ON p.plan_id = i.plan_id)
BEGIN
	RAISERROR ('No existe el plan para el cual se compra el bono', 16, 1);
	RETURN
END;

INSERT INTO KFC.bonos(afil_id, plan_id, consumido, fecha_compra, fecha_impresion)
	VALUES(
	 (SELECT afil_id FROM inserted),
	 (SELECT plan_id FROM inserted), 
	 (SELECT consumido FROM inserted), 
	 (SELECT fecha_compra FROM inserted), 
	 (SELECT fecha_impresion FROM inserted)
	 );
GO

/* TRIGGER NO NECESARIO
---------------------------------------------------------------------------
-- Trigger para chequear la fecha de la impresion del bono --
CREATE TRIGGER KFC.impresion_bono
ON KFC.bonos
INSTEAD OF UPDATE AS

IF UPDATE(fecha_impresion)
BEGIN
	IF((SELECT fecha_impresion FROM inserted) < (SELECT fecha_compra FROM inserted))
	BEGIN
		RAISERROR ('La fecha de impresión no puede ser anterior a la fecha de la compra del bono', 16, 1);
		RETURN
	END;
END

ARREGLAR
GO
*/
---------------------------------------------------------------------------

-- Trigger para chequear la informacion del turno --
CREATE TRIGGER KFC.nuevo_turno
ON KFC.turnos
INSTEAD OF INSERT AS
IF NOT EXISTS (SELECT * FROM KFC.afiliados WHERE afil_id = (SELECT afil_id FROM inserted))
BEGIN
	RAISERROR ('No existe el afiliado que intenta solicitar el turno', 16, 1);
	RETURN
END;
IF NOT EXISTS (SELECT * FROM KFC.profesionales 
	WHERE prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('No existe el profesional indicado', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades 
	WHERE espe_id = (SELECT espe_id FROM inserted))
	BEGIN
		RAISERROR ('No existe la especialidad indicada', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades_profesional 
	WHERE espe_id = (SELECT espe_id FROM inserted) AND prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('El profesional no tiene la especialidad indicada', 16, 1);
		RETURN
	END;

INSERT INTO KFC.turnos(afil_id, espe_id, prof_id, fecha_hora, hora)
	VALUES(
	 (SELECT afil_id FROM inserted), 
	 (SELECT espe_id FROM inserted), 
	 (SELECT prof_id FROM inserted),
	 (SELECT fecha_hora FROM inserted), 
	 (SELECT hora FROM inserted)
	 );
GO
---------------------------------------------------------------------------


PRINT 'TRIGGERS CREADOS'
PRINT '------------------'
PRINT 'Fin Script'