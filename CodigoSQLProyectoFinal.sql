use PapelGive
CREATE TABLE Clientes(
	id_cliente varchar (10) PRIMARY KEY,
	PrimerNom_cli varchar(25) NOT NULL,
	SegundoNom_cli varchar(25) NOT NULL,
	PrimerApp_cli varchar(25) NOT NULL,
	SegundoApp_cli varchar(25) NOT NULL,
	dir_cli varchar(22) NOT NULL,
	tel_cli varchar(10) NOT NULL,
	correo_elect varchar (50) NOT NULL,
	Nombre_empresa varchar(25) NOT NULL,
	Ruc varchar (13) NOT NULL
);
CREATE TABLE Sede (
  nombreSede varchar(15) PRIMARY KEY,
);
CREATE TABLE Empleados (
	id_empleado varchar (10) PRIMARY KEY,
	PrimerNom_cli varchar(25) NOT NULL,
	SegundoNom_cli varchar(25) NOT NULL,
	PrimerApp_cli varchar(25) NOT NULL,
	SegundoApp_cli varchar(25) NOT NULL,
	dir_cli varchar(30) NOT NULL,
	tel_cli varchar(10) NOT NULL,
	rol varchar (15) NOT NULL,
	correo varchar (30) NOT NULL,
  	ocupacion varchar (30) NOT NULL,
	clave varchar(20) NOT NULL,
  	nomb_usuario varchar(20) UNIQUE,
  	nombreSede varchar(15) NOT NULL,
  	sueldo decimal(9, 2) NOT NULL,
	CONSTRAINT UQ_Empleado_Rol UNIQUE (id_empleado, rol) ,
	CONSTRAINT UQ_Empleado_Sede UNIQUE (id_empleado, nombreSede),
	FOREIGN KEY (nombreSede) REFERENCES Sede(nombreSede)
);
CREATE TABLE Productos (
  id_producto int PRIMARY KEY,
  nombre_prod varchar(30) NOT NULL,
  precio_porPaq decimal(7, 2) NOT NULL,
  cant int NULL,
);
CREATE TABLE FacturasV (
  num_factura int PRIMARY KEY,
  total decimal(9, 2) NOT NULL,
  iva decimal(9, 2) NOT NULL,
  fecha_fact date NOT NULL,
  id_cliente varchar(10) NOT NULL,
  modoPago varchar(20) NOT NULL,
  FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente) ON DELETE CASCADE,
  CONSTRAINT UQ_numFac_fecha UNIQUE (num_factura, fecha_fact) 
);
CREATE TABLE Proveedores (
  id_proveedor varchar(13) PRIMARY KEY,
  nombre_prov varchar(20) UNIQUE,
  correo_elect varchar(20) NOT NULL,
  tel_prov varchar(10) NOT NULL,
  dir_prov varchar(20) NOT NULL,
  nombreSede varchar(15) NOT NULL,
  FOREIGN KEY (nombreSede) REFERENCES Sede(nombreSede)
);

CREATE TABLE ItemsV (
  cant int NULL,
  num_factura int NOT NULL,
  id_producto int NOT NULL
  PRIMARY KEY (id_producto,num_factura),
  FOREIGN KEY (num_factura) REFERENCES FacturasV(num_factura),
  FOREIGN KEY (id_producto) REFERENCES Productos(id_producto) ON DELETE CASCADE
);
CREATE TABLE NumeroOrdenCompra (
  num_orden int PRIMARY KEY,
  total decimal(9, 2) NOT NULL,
  iva decimal(9, 2) NOT NULL,
  fecha_adq date NOT NULL,
  modoPag varchar(30) NOT NULL,
  CONSTRAINT UQ_numOrd_fecha UNIQUE (num_orden, fecha_adq)
);
CREATE TABLE ItemsC (
  cant int NULL,
  num_orden int NOT NULL,
  id_producto int NOT NULL,
  id_proveedor varchar(13) NULL,
  PRIMARY KEY (num_orden, id_producto),
  FOREIGN KEY (num_orden) REFERENCES NumeroOrdenCompra(num_orden),
  FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
  FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor) ON DELETE CASCADE
);
CREATE TABLE Caja (
   codigoCierreCaja int PRIMARY KEY,
   fecha date NOT NULL,
   nomb_usuario varchar(20) NOT NULL,
   montoInicial decimal(9, 2) NOT NULL,
   montoCierre decimal(9, 2) NOT NULL,
   totalTransG decimal(9, 2) NOT NULL,
   totalEfectG decimal(9, 2) NOT NULL,
   GastosTotales decimal(9, 2) NOT NULL,
   totalTransI decimal(9, 2) NOT NULL,
   totalEfectI decimal(9, 2) NOT NULL,
   IngresosTotales decimal(9, 2) NOT NULL,
   FOREIGN KEY (nomb_usuario) REFERENCES Empleados(nomb_usuario) ON DELETE CASCADE,
);
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1782903982', N'Veronica', N'Fernanda', N'Heredia', N'Tumbaco', N'18 de noviembre', N'0996558715', N'VeronicaFe rnanda@gmail.com', N'GuarderiaSue as', N'1782903982008');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1728394093', N'Maria', N'Karla', N'Fillon', N'Guaman ', N'Shyris ', N'0975823558', N'MariaKarla@gmail.com', N'AlmacenesJumpy', N'1728394093002');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1782938473', N'Gloria', N'Estefania', N'Yepez', N'Salsedo', N'Napo', N'0995763221', N'GloriaEstefania@gmail.com', N'AcademyDancing', N'1782938473021');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1790237402', N'Esperanza', N'Roberta', N'Gomez', N'Rodrigez', N'Col n', N'0992351478', N'EsperanzaRoberta@gmail.com', N'VillaTodo', N'1790237402087');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1728393943', N'Jessica', N'Patricia', N'Gonzales', N'Noboa', N'Acacias', N'0951396578', N'JessicaPatricia@gmail.com', N'El Todo Bien', N'1728393943007');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('5293837463', N'Fabricio', N'Carlos', N'Jimenez', N'Tiron', N'R o Bobonaza', N'0965147896', N'FabricioCarlos@gmail.com', N'Vive y Sue a', N'5293837463098');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('8299182736', N'Byron', N'Juan', N'Yucta', N'Llano', N'Eloy Alfaro', N'0985632148', N'JuanByron@gmail.com', N'TiaMia', N'8299182736017');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1928872622', N'Monica', N'Valeria', N'Alzar', N'Caicedo', N'San Pedro', N'0978512369', N'MonicaValeria@gmail.com', N'OlaGrande', N'1928872622009');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1928878631', N'Bryan', N'Alexander', N'Vera', N'Avila', N'Martha Bucaram', N'0978512370', N'BryanVera@gmail.com', N'Tuti', N'1927080622009');
INSERT INTO Clientes ([id_cliente], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli], [correo_elect], [Nombre_empresa], [Ruc]) VALUES ('1751360799', N'Jean', N'Carlos', N'Alcivar', N'Mendez', N'La Ecuatoriana', N'0978514041', N'jeanxd20@gmail.com', N'San Mart�n', N'192889086019');

INSERT INTO Sede (nombreSede) values (N'Quito');

INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1782305982', N'Selena', N'Maria', N'Heredia', N'Cordova', N'18 de noviembre', N'0996797745', N'Empleado', N'SeleCo@gmail.com',N'Vigilador', N'sele1234', N'selecor12', N'Quito', CAST(480.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1380305982', N'Andres', N'Cristian', N'Perez', N'Altamirano', N'10 de agosto', N'0996797745', N'Administrador', N'AndePer@gmail.com',N'Animador', N'andrescris14', N'andecri12', N'Quito', CAST(480.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1784505982', N'Erik', N'Alexander', N'Armijos', N'Salda�a', N'Martha Bucaram', N'0989797745', N'Administrador', N'erikarmijos@gmail.com',N'Vigilador', N'erik12345', N'erik21', N'Quito', CAST(480.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1782365978', N'Jesica', N'Lorena', N'Erazo', N'Saltos', N'Marin', N'0999654745', N'Coordinador', N'jesicaerazo@gmail.com',N'Empleado', N'jesica014', N'jesica15', N'Quito', CAST(500.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1302005982', N'Lorena', N'Paola', N'Gutierrez', N'Gavilanez', N'El Giron', N'0996993150', N'Impulsor', N'paola14@gmail.com',N'Repartidor', N'paola124', N'paola72', N'Quito', CAST(475.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1782379698', N'Gabriela', N'Lizeth', N'Chancusig', N'Velasquez', N'Chillogallo', N'0978607745', N'Empleado', N'gabylitzh@gmail.com',N'Investigador de Recursos', N'gaby1454', N'gaby78', N'Quito', CAST(500.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1725605782', N'Eduardo', N'Estalin', N'Heredia', N'Toapanta', N'Solanda', N'0978563745', N'Empleado', N'Eduhere@gmail.com',N'Vendedor', N'eduheredia', N'eduardoheredia', N'Quito', CAST(450.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1782393602', N'Cristian', N'Luis', N'Lara', N'Martinez', N'12 de Octubre', N'0997850142', N'Empleado', N'laramartinez@gmail.com',N'Vendedor', N'cristian78', N'lara2002', N'Quito', CAST(450.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1780023982', N'Jose', N'Luis', N'Saltos', N'Chancay', N'Puembo', N'0995655301', N'Empleado', N'joseluis@gmail.com',N'Cajero', N'joseluis11', N'joseluis65', N'Quito', CAST(450.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1364259821', N'Kevin', N'Marco', N'Perea', N'Gregorio', N'Santa Clara', N'0986643011', N'Empleado', N'kevinperea@gmail.com',N'Repartidor', N'kevinperea392', N'kevinperea', N'Quito', CAST(450.00 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1752208452', N'Cristian', N'Daniel', N'Diaz', N'Eras', N'La Ecuatoriana', N'0998376536', N'Administrador', N'cristian.diaz02@gmail.com',N'Administrador', N'grupo5', N'cristiangrupo5', N'Quito', CAST(900.50 AS Decimal(9, 2)));
INSERT INTO Empleados ([id_empleado], [PrimerNom_cli], [SegundoNom_cli], [PrimerApp_cli], [SegundoApp_cli], [dir_cli], [tel_cli],  [rol], [correo], [ocupacion], [clave], [nomb_usuario], [nombreSede], [sueldo]) VALUES  ('1982736378', N'Nelson', N'Steven', N'Casa', N'Velasquez', N'La Floresta', N'0983374666', N'Administrador', N'nelson.casa22@gmail.com',N'Administrador', N'grupocinco', N'nelsongrupo5', N'Quito', CAST(982.90 AS Decimal(9, 2)));

INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (12873, N'Hojas a Cuadros',  CAST(0.75 AS Decimal(7, 2)), 190);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (29827, N'Borradores', CAST(2.00 AS Decimal(7, 2)), 67);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (32432, N'Hojas de papel Bond', CAST(4.00 AS Decimal(7, 2)),262);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (45343, N'Goma l�quida', CAST(4.00 AS Decimal(7, 2)), 188);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (51122, N'Esferos', CAST(4.50 AS Decimal(7, 2)),190);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (61211, N'Tijeras', CAST(5.00 AS Decimal(7, 2)),288);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (32117, N'Caja de pinturas', CAST(25.00 AS Decimal(7, 2)),411);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (23338, N'Escarchas', CAST(6.00 AS Decimal(7, 2)), 431);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (91211, N'Papelotes', CAST(4.00 AS Decimal(7, 2)), 122);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (11210, N'Cinta Scotch', CAST(10.00 AS Decimal(7, 2)), 221);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (67511, N'Hojas de papel ministro', CAST(3.80 AS Decimal(7, 2)), null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (13322, N'Cartulinas A4', CAST(3.50 AS Decimal(7, 2)), null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (13121, N'Cuaderno universitario de 100 hojas', CAST(15.60 AS Decimal(7, 2)), null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (15544, N'Cuaderno universitario de 200 hojas', CAST(29.00 AS Decimal(7, 2)), null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (15321, N'Forro de cuaderno', CAST(5.00 AS Decimal(7, 2)), null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (16433, N'Carpetas de papel', CAST(5.80 AS Decimal(7, 2)), null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (12317, N'Lapiz HB', CAST(4.00 AS Decimal(7, 2)), 292);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (12328, N'Marcadores de tiza liqu�da', CAST(9.00 AS Decimal(7, 2)),111);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (19233, N'Grapadora', CAST(2.00 AS Decimal(7, 2)),112);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (20233, N'Peforadora', CAST(2.75 AS Decimal(7, 2)),252);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (21233, N'Sacapuntas', CAST(3.00 AS Decimal(7, 2)),552);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (22233, N'Fomix', CAST(1.75 AS Decimal(7, 2)),911);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (23111, N'Sobres de manila', CAST(4.50 AS Decimal(7, 2)),221);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (23224, N'Corrector', CAST(10.00 AS Decimal(7, 2)),null);
INSERT INTO Productos ([id_producto], [nombre_prod], [precio_porPaq], [cant]) VALUES (78325, N'Portaminas', CAST(10.80 AS Decimal(7, 2)),110);

INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (89822, CAST(1000.00 AS Decimal(9, 2)), CAST(120.00 AS Decimal(9, 2)), CAST(N'2021-03-08' AS Date), '1751360799', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (82987, CAST(20.00 AS Decimal(9, 2)), CAST(2.40 AS Decimal(9, 2)), CAST(N'2021-02-16' AS Date), '1751360799', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (92198, CAST(55.00 AS Decimal(9, 2)), CAST(6.60 AS Decimal(9, 2)), CAST(N'2020-07-18' AS Date), '1751360799', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (32332, CAST(80.00 AS Decimal(9, 2)), CAST(9.60 AS Decimal(9, 2)), CAST(N'2021-01-10' AS Date), '1751360799', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (42132, CAST(10.00 AS Decimal(9, 2)), CAST(1.20 AS Decimal(9, 2)), CAST(N'2020-04-09' AS Date), '1728394093', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (51111, CAST(450.00 AS Decimal(9, 2)), CAST(54.00 AS Decimal(9, 2)), CAST(N'2020-09-01' AS Date), '1728394093', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (21126, CAST(1000.00 AS Decimal(9, 2)), CAST(120.00 AS Decimal(9, 2)), CAST(N'2021-03-08' AS Date), '1782938473', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (73211, CAST(335.00 AS Decimal(9, 2)), CAST(40.20 AS Decimal(9, 2)), CAST(N'2020-01-02' AS Date), '1782938473', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (32118, CAST(2500.00 AS Decimal(9, 2)), CAST(300.00 AS Decimal(9, 2)), CAST(N'2021-04-25' AS Date),'1782938473', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (93222, CAST(98.00 AS Decimal(9, 2)), CAST(11.76 AS Decimal(9, 2)), CAST(N'2021-03-19' AS Date), '1790237402', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (10121, CAST(80.00 AS Decimal(9, 2)), CAST(9.60 AS Decimal(9, 2)), CAST(N'2020-12-23' AS Date), '1790237402', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (11321, CAST(400.00 AS Decimal(9, 2)), CAST(48.00 AS Decimal(9, 2)), CAST(N'2021-01-11' AS Date), '1790237402', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (12321, CAST(189.00 AS Decimal(9, 2)), CAST(22.68 AS Decimal(9, 2)), CAST(N'2020-12-30' AS Date), '1728393943', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (13413, CAST(75.00 AS Decimal(9, 2)), CAST(9.00 AS Decimal(9, 2)), CAST(N'2020-07-18' AS Date), '5293837463', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (15474, CAST(455.00 AS Decimal(9, 2)), CAST(54.60 AS Decimal(9, 2)), CAST(N'2021-01-10' AS Date), '5293837463', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (18775, CAST(500.00 AS Decimal(9, 2)), CAST(60.00 AS Decimal(9, 2)), CAST(N'2020-04-09' AS Date), '5293837463', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (16575, CAST(750.00 AS Decimal(9, 2)), CAST(90.00 AS Decimal(9, 2)), CAST(N'2020-09-01' AS Date), '5293837463', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (23517, CAST(900.00 AS Decimal(9, 2)), CAST(108.00 AS Decimal(9, 2)), CAST(N'2021-03-08' AS Date), '5293837463', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (13428, CAST(225.00 AS Decimal(9, 2)), CAST(27.00 AS Decimal(9, 2)), CAST(N'2020-01-02' AS Date), '8299182736', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (23419, CAST(2000.00 AS Decimal(9, 2)), CAST(240.00 AS Decimal(9, 2)), CAST(N'2021-04-25' AS Date), '8299182736', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (23220, CAST(390.00 AS Decimal(9, 2)), CAST(46.80 AS Decimal(9, 2)), CAST(N'2021-03-19' AS Date), '1928872622', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (22221, CAST(600.00 AS Decimal(9, 2)), CAST(72.00 AS Decimal(9, 2)), CAST(N'2020-12-23' AS Date), '1928872622', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (22222, CAST(145.00 AS Decimal(9, 2)), CAST(17.40 AS Decimal(9, 2)), CAST(N'2021-01-11' AS Date), '1928872622', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (23453, CAST(770.00 AS Decimal(9, 2)), CAST(92.40 AS Decimal(9, 2)), CAST(N'2020-12-30' AS Date), '1928872622', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (11214, CAST(490.00 AS Decimal(9, 2)), CAST(58.80 AS Decimal(9, 2)), CAST(N'2021-01-11' AS Date), '1928872622', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (20125, CAST(525.00 AS Decimal(9, 2)), CAST(63.00 AS Decimal(9, 2)), CAST(N'2021-01-11' AS Date), '1928878631', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (10926, CAST(689.00 AS Decimal(9, 2)), CAST(82.68 AS Decimal(9, 2)), CAST(N'2020-12-30' AS Date), '1928878631', N'Transferencia');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (00227, CAST(99.00 AS Decimal(9, 2)), CAST(11.88 AS Decimal(9, 2)), CAST(N'2020-12-30' AS Date), '1751360799', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (09228, CAST(633.00 AS Decimal(9, 2)), CAST(75.96 AS Decimal(9, 2)), CAST(N'2020-07-18' AS Date), '1751360799', N'Efectivo');
INSERT INTO FacturasV ([num_factura], [total], [iva], [fecha_fact], [id_cliente], [modoPago]) VALUES (91929, CAST(875.00 AS Decimal(9, 2)), CAST(105.00 AS Decimal(9, 2)), CAST(N'2021-01-10' AS Date), '1751360799', N'Efectivo');

INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'2783782781121', N'Papelesa', N'papelesa@gmail.com', N'0983205598', N'Quitumbe', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'2892837626732', N'Grupo 100', N'grupo100@gmail.com', N'0932000489', N'Las Pe�as', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'3221112132342', N'Standler', N'Standler@gmail.com', N'0922205598', N'Remigio', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'4322110309023', N'Pelikan', N'pelikanec@gmail.com', N'0981800971', N'Alborada', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'1152321231102', N'Carioca', N'carioca@gmail.com', N'0911806948', N'Velez y Roman', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'1328329837728', N'Guiotto', N'guiotto@gmail.com', N'0923040822', N'Rocafuerte', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'2090292898333', N'LNS', N'lnsecuador@gmail.com', N'0991800255', N'P o Jaramillo', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'9382378338278', N'Estilo', N'estilo@gmail.com', N'0920004255', N'Kennedy', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'3829839828782', N'Bic', N'bicecuador@gmail.com', N'0991500755', N'Av. 12 de Febrero', N'Quito');
INSERT INTO Proveedores ([id_proveedor], [nombre_prov], [correo_elect], [tel_prov], [dir_prov], [nombreSede]) VALUES (N'1023982983982', N'Norma', N'normaecuador@gmail.com', N'0961800766', N'Calle 05 de Julio ', N'Quito');

INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (12873, 1, 89822);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (32432, 1, 82987);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (45343, 1, 92198);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (32117, 2, 32332);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (23338, 2, 42132);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (45343, 2, 51111);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (11210, 2, 21126);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (67511, 2, 73211);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (13322, 2, 32118);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (78325, 3, 93222);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (32432, 3, 10121);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (29827, 3, 11321);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (12873, 4, 12321);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (51122, 4, 13413);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (78325, 4, 15474);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (23224, 5, 18775);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (23338, 5, 16575);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (11210, 6, 23517);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (45343, 6, 13428);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (22233, 6, 23419);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (23224, 7, 23220);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (16433, 7, 22221);
INSERT INTO ItemsV ([id_producto], [cant], [num_factura]) VALUES (23338, 8, 22222);

INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12312, CAST(37.50 AS Decimal(9, 2)), CAST(2.50 AS Decimal(9, 2)), CAST(N'2021-01-10' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12222, CAST(80.00 AS Decimal(9, 2)), CAST(3.00 AS Decimal(9, 2)), CAST(N'2021-01-12' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (21313, CAST(200.00 AS Decimal(9, 2)), CAST(10.00 AS Decimal(9, 2)), CAST(N'2021-01-12' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (32224, CAST(160.00 AS Decimal(9, 2)), CAST(8.00 AS Decimal(9, 2)), CAST(N'2021-01-13' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (32115, CAST(135.00 AS Decimal(9, 2)), CAST(5.00 AS Decimal(9, 2)), CAST(N'2021-01-13' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (64422, CAST(175.00 AS Decimal(9, 2)), CAST(15.00 AS Decimal(9, 2)), CAST(N'2021-01-13' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (72389, CAST(500.00 AS Decimal(9, 2)), CAST(25.00 AS Decimal(9, 2)), CAST(N'2021-01-13' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (83253, CAST(150.00 AS Decimal(9, 2)), CAST(5.60 AS Decimal(9, 2)), CAST(N'2021-01-15' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (93423, CAST(40.00 AS Decimal(9, 2)), CAST(2.00 AS Decimal(9, 2)), CAST(N'2021-01-16' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12110, CAST(50.00 AS Decimal(9, 2)), CAST(5.00 AS Decimal(9, 2)), CAST(N'2021-01-16' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12311, CAST(38.00 AS Decimal(9, 2)), CAST(1.80 AS Decimal(9, 2)), CAST(N'2021-01-16' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12112, CAST(42.00 AS Decimal(9, 2)), CAST(4.00 AS Decimal(9, 2)), CAST(N'2021-01-17' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (11113, CAST(156.00 AS Decimal(9, 2)), CAST(11.50 AS Decimal(9, 2)), CAST(N'2021-01-17' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (14111, CAST(290.60 AS Decimal(9, 2)), CAST(21.50 AS Decimal(9, 2)), CAST(N'2021-01-18' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (13215, CAST(45.00 AS Decimal(9, 2)), CAST(2.90 AS Decimal(9, 2)), CAST(N'2021-01-18' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12316, CAST(75.40 AS Decimal(9, 2)), CAST(3.60 AS Decimal(9, 2)), CAST(N'2021-01-19' AS Date), N'Effectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (09217, CAST(120.00 AS Decimal(9, 2)), CAST(12.00 AS Decimal(9, 2)), CAST(N'2021-01-19' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (20018, CAST(81.00 AS Decimal(9, 2)), CAST(6.30 AS Decimal(9, 2)), CAST(N'2021-01-20' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12029, CAST(40.00 AS Decimal(9, 2)), CAST(4.10 AS Decimal(9, 2)), CAST(N'2021-01-20' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (20020, CAST(55.00 AS Decimal(9, 2)), CAST(6.20 AS Decimal(9, 2)), CAST(N'2021-01-20' AS Date), N'Transferencia');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (20111, CAST(9.00 AS Decimal(9, 2)), CAST(0.89 AS Decimal(9, 2)), CAST(N'2021-01-21' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (12022, CAST(12.25 AS Decimal(9, 2)), CAST(0.88 AS Decimal(9, 2)), CAST(N'2021-01-22' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (09292, CAST(67.50 AS Decimal(9, 2)), CAST(6.40 AS Decimal(9, 2)), CAST(N'2021-01-22' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (00222, CAST(60.00 AS Decimal(9, 2)), CAST(7.60 AS Decimal(9, 2)), CAST(N'2021-01-23' AS Date), N'Efectivo');
INSERT INTO NumeroOrdenCompra ([num_orden], [total], [iva], [fecha_adq], [modoPag]) VALUES (02911, CAST(108.00 AS Decimal(9, 2)), CAST(6.48 AS Decimal(9, 2)), CAST(N'2021-01-23' AS Date), N'Transferencia');

INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (50, 12312, 12873,N'2783782781121');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (40, 12112, 32432,N'2892837626732');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (50, 13215, 29827,N'9382378338278');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (40, 20020, 45343,N'4322110309023');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (30, 09292, 61211,N'1152321231102');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (35, 02911, 32432,N'2090292898333');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (20, 12022, 12873,N'2892837626732');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (25, 20018, 61211,N'3829839828782');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (10, 02911, 15321,N'1023982983982');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (5, 12312, 45343,N'4322110309023');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (10, 09292, 15321,N'1023982983982');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (12, 12022, 20233,N'3829839828782');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (10, 20018, 45343,N'3221112132342');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (10, 20020, 32117,N'1023982983982');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (9, 12312, 12873,N'1152321231102');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (13, 12112, 61211,N'2892837626732');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (30, 13215, 20233,N'1328329837728');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (9, 12312, 29827,N'2090292898333');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (20, 02911, 51122,N'1023982983982');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (20, 14111, 32117,N'1328329837728');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (3, 14111, 32432,N'3221112132342');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (20, 20018, 12873,N'9382378338278');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (15, 14111, 51122,N'2090292898333');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (6, 09292, 32432,N'4322110309023');
INSERT INTO ItemsC ([cant], [num_orden], [id_producto], [id_proveedor]) VALUES (10, 12022, 12873,N'3221112132342');

INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (09382,CAST(N'2021-01-23' AS Date), N'cristiangrupo5', CAST(800.00 AS Decimal(9, 2)), CAST(1028.48 AS Decimal(9, 2)), CAST(108.48 AS Decimal(9, 2)), CAST(138.48 AS Decimal(9, 2)), CAST(90.08 AS Decimal(9, 2)),CAST(1110.48 AS Decimal(9, 2)),CAST(5002.48 AS Decimal(9, 2)), CAST(9928.11 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (29898, CAST(N'2021-02-16' AS Date), N'cristiangrupo5', CAST(900.00 AS Decimal(9, 2)), CAST(1200.25 AS Decimal(9, 2)), CAST(150.75 AS Decimal(9, 2)), CAST(180.25 AS Decimal(9, 2)), CAST(120.50 AS Decimal(9, 2)), CAST(1350.25 AS Decimal(9, 2)), CAST(5200.75 AS Decimal(9, 2)), CAST(10250.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (23992, CAST(N'2020-07-18' AS Date), N'andecri12', CAST(750.00 AS Decimal(9, 2)), CAST(1100.75 AS Decimal(9, 2)), CAST(120.25 AS Decimal(9, 2)), CAST(160.75 AS Decimal(9, 2)), CAST(90.50 AS Decimal(9, 2)), CAST(950.75 AS Decimal(9, 2)), CAST(4200.25 AS Decimal(9, 2)), CAST(9850.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (89995, CAST(N'2021-01-10' AS Date), N'jesica15', CAST(950.00 AS Decimal(9, 2)), CAST(1350.25 AS Decimal(9, 2)), CAST(180.75 AS Decimal(9, 2)), CAST(220.25 AS Decimal(9, 2)), CAST(150.50 AS Decimal(9, 2)), CAST(1200.25 AS Decimal(9, 2)), CAST(5500.75 AS Decimal(9, 2)), CAST(10650.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (09386, CAST(N'2020-04-09' AS Date), N'paola72', CAST(800.00 AS Decimal(9, 2)), CAST(1120.75 AS Decimal(9, 2)), CAST(140.75 AS Decimal(9, 2)), CAST(160.25 AS Decimal(9, 2)), CAST(100.50 AS Decimal(9, 2)), CAST(1100.25 AS Decimal(9, 2)), CAST(4900.75 AS Decimal(9, 2)), CAST(9600.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (19387, CAST(N'2020-09-01' AS Date), N'erik21', CAST(900.00 AS Decimal(9, 2)), CAST(1250.75 AS Decimal(9, 2)), CAST(160.25 AS Decimal(9, 2)), CAST(200.75 AS Decimal(9, 2)), CAST(120.50 AS Decimal(9, 2)), CAST(1300.25 AS Decimal(9, 2)), CAST(5800.75 AS Decimal(9, 2)), CAST(11350.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (33388, CAST(N'2021-03-08' AS Date), N'gaby78', CAST(850.00 AS Decimal(9, 2)), CAST(1180.75 AS Decimal(9, 2)), CAST(145.25 AS Decimal(9, 2)), CAST(175.75 AS Decimal(9, 2)), CAST(110.50 AS Decimal(9, 2)), CAST(1200.25 AS Decimal(9, 2)), CAST(5500.75 AS Decimal(9, 2)), CAST(10780.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (78989, CAST(N'2020-01-02' AS Date), N'eduardoheredia', CAST(750.00 AS Decimal(9, 2)), CAST(1025.25 AS Decimal(9, 2)), CAST(130.25 AS Decimal(9, 2)), CAST(160.75 AS Decimal(9, 2)), CAST(95.50 AS Decimal(9, 2)), CAST(1100.25 AS Decimal(9, 2)), CAST(4800.75 AS Decimal(9, 2)), CAST(9425.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (09390, CAST(N'2021-04-25' AS Date), N'cristiangrupo5', CAST(950.00 AS Decimal(9, 2)), CAST(1275.25 AS Decimal(9, 2)), CAST(165.25 AS Decimal(9, 2)), CAST(205.75 AS Decimal(9, 2)), CAST(125.50 AS Decimal(9, 2)), CAST(1350.25 AS Decimal(9, 2)), CAST(5900.75 AS Decimal(9, 2)), CAST(11625.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (99388, CAST(N'2021-03-19' AS Date), N'nelsongrupo5', CAST(1100.00 AS Decimal(9, 2)), CAST(1425.25 AS Decimal(9, 2)), CAST(185.25 AS Decimal(9, 2)), CAST(220.75 AS Decimal(9, 2)), CAST(135.50 AS Decimal(9, 2)), CAST(1550.25 AS Decimal(9, 2)), CAST(6500.75 AS Decimal(9, 2)), CAST(12450.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (82111, CAST(N'2020-12-23' AS Date), N'kevinperea', CAST(880.00 AS Decimal(9, 2)), CAST(1155.25 AS Decimal(9, 2)), CAST(155.25 AS Decimal(9, 2)), CAST(190.75 AS Decimal(9, 2)), CAST(130.50 AS Decimal(9, 2)), CAST(1450.25 AS Decimal(9, 2)), CAST(6200.75 AS Decimal(9, 2)), CAST(12055.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (11111, CAST(N'2021-01-11' AS Date), N'lara2002', CAST(920.00 AS Decimal(9, 2)), CAST(1275.25 AS Decimal(9, 2)), CAST(170.25 AS Decimal(9, 2)), CAST(200.75 AS Decimal(9, 2)), CAST(140.50 AS Decimal(9, 2)), CAST(1350.25 AS Decimal(9, 2)), CAST(6100.75 AS Decimal(9, 2)), CAST(11725.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (09394, CAST(N'2020-12-30' AS Date), N'lara2002', CAST(950.00 AS Decimal(9, 2)), CAST(1320.25 AS Decimal(9, 2)), CAST(175.25 AS Decimal(9, 2)), CAST(215.75 AS Decimal(9, 2)), CAST(145.50 AS Decimal(9, 2)), CAST(1570.25 AS Decimal(9, 2)), CAST(6800.75 AS Decimal(9, 2)), CAST(13120.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (91395, CAST(N'2020-07-18' AS Date), N'andecri12', CAST(850.00 AS Decimal(9, 2)), CAST(1175.25 AS Decimal(9, 2)), CAST(160.25 AS Decimal(9, 2)), CAST(195.75 AS Decimal(9, 2)), CAST(125.50 AS Decimal(9, 2)), CAST(1350.25 AS Decimal(9, 2)), CAST(5800.75 AS Decimal(9, 2)), CAST(11275.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (11200, CAST(N'2021-01-10' AS Date), N'erik21', CAST(900.00 AS Decimal(9, 2)), CAST(1250.25 AS Decimal(9, 2)), CAST(165.25 AS Decimal(9, 2)), CAST(200.75 AS Decimal(9, 2)), CAST(130.50 AS Decimal(9, 2)), CAST(1400.25 AS Decimal(9, 2)), CAST(6200.75 AS Decimal(9, 2)), CAST(12125.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (88888, CAST(N'2020-04-09' AS Date), N'jesica15', CAST(950.00 AS Decimal(9, 2)), CAST(1320.25 AS Decimal(9, 2)), CAST(175.25 AS Decimal(9, 2)), CAST(215.75 AS Decimal(9, 2)), CAST(145.50 AS Decimal(9, 2)), CAST(1570.25 AS Decimal(9, 2)), CAST(6800.75 AS Decimal(9, 2)), CAST(13120.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (09398, CAST(N'2020-09-01' AS Date), N'paola72', CAST(880.00 AS Decimal(9, 2)), CAST(1225.25 AS Decimal(9, 2)), CAST(165.25 AS Decimal(9, 2)), CAST(205.75 AS Decimal(9, 2)), CAST(140.50 AS Decimal(9, 2)), CAST(1500.25 AS Decimal(9, 2)), CAST(6500.75 AS Decimal(9, 2)), CAST(12625.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (99999, CAST(N'2021-03-08' AS Date), N'gaby78', CAST(920.00 AS Decimal(9, 2)), CAST(1270.25 AS Decimal(9, 2)), CAST(165.25 AS Decimal(9, 2)), CAST(200.75 AS Decimal(9, 2)), CAST(140.50 AS Decimal(9, 2)), CAST(1550.25 AS Decimal(9, 2)), CAST(6700.75 AS Decimal(9, 2)), CAST(12850.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (19420, CAST(N'2021-03-19' AS Date), N'nelsongrupo5', CAST(950.00 AS Decimal(9, 2)), CAST(1300.25 AS Decimal(9, 2)), CAST(170.25 AS Decimal(9, 2)), CAST(210.75 AS Decimal(9, 2)), CAST(140.50 AS Decimal(9, 2)), CAST(1500.25 AS Decimal(9, 2)), CAST(6500.75 AS Decimal(9, 2)), CAST(-12600.50 AS Decimal(9, 2)));
INSERT INTO Caja ([codigoCierreCaja], [fecha], [nomb_usuario], [montoInicial], [montoCierre], [totalTransG], [totalEfectG], [GastosTotales], [totalTransI], [totalEfectI], [IngresosTotales]) VALUES (43441, CAST(N'2020-12-23' AS Date), N'nelsongrupo5', CAST(880.00 AS Decimal(9, 2)), CAST(1220.25 AS Decimal(9, 2)), CAST(160.25 AS Decimal(9, 2)), CAST(200.75 AS Decimal(9, 2)), CAST(135.50 AS Decimal(9, 2)), CAST(1450.25 AS Decimal(9, 2)), CAST(6200.75 AS Decimal(9, 2)), CAST(-12020.50 AS Decimal(9, 2)));


--------------------------Buscar Nombre Cliente-------------------
GO
CREATE PROCEDURE sp_BuscarNom_Cli
@Buscar varchar(100)
AS
BEGIN
SELECT 
PrimerNom_cli + ' ' + SegundoNom_cli + ' ' + PrimerApp_cli + ' ' + SegundoApp_cli AS 'Nombre del Cliente',
id_cliente AS Cedula,
Nombre_empresa AS 'Nombre Empresarial',
RUC	AS RUC,
tel_cli AS 'Telefono Celular',
correo_elect AS 'Correo Electronico',
dir_cli AS 'Direccion'
FROM Clientes 
WHERE 
(PrimerNom_cli + ' ' + SegundoNom_cli + ' ' + PrimerApp_cli + ' ' + SegundoApp_cli) LIKE @Buscar+'%' or id_cliente LIKE @Buscar +'%'
END;
--------------------------Insertar Cliente--------------------------------
GO
CREATE PROCEDURE sp_InsertarCliente
    @Cedula varchar(10),
    @PrimerNombre varchar(25),
    @SegundoNombre varchar(25),
    @PrimerApellido varchar(25),
    @SegundoApellido varchar(25),
    @Direccion varchar(22),
    @Telefono varchar(10),
    @Correo varchar(50),
    @NombreEmpresa varchar(25),
    @Ruc varchar(13)
AS
BEGIN
    INSERT INTO Clientes (id_cliente, PrimerNom_cli, SegundoNom_cli, PrimerApp_cli, SegundoApp_cli, dir_cli, tel_cli, correo_elect, Nombre_empresa, Ruc)
    VALUES (@Cedula, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Direccion, @Telefono, @Correo, @NombreEmpresa, @Ruc)
END;
GO
-------------------------Modificar Cliente------------------------------
CREATE PROCEDURE sp_ModificarCliente
    @Cedula varchar(10),
    @PrimerNombre varchar(25),
    @SegundoNombre varchar(25),
    @PrimerApellido varchar(25),
    @SegundoApellido varchar(25),
    @Direccion varchar(22),
    @Telefono varchar(10),
    @Correo varchar(50),
    @NombreEmpresa varchar(25),
    @Ruc varchar(13)
AS
BEGIN
    UPDATE Clientes
	SET id_cliente = @Cedula,
		PrimerNom_cli = @PrimerNombre,
		SegundoNom_cli= @SegundoNombre,
		PrimerApp_cli = @PrimerApellido,
	    SegundoApp_cli = @SegundoApellido,
		dir_cli = @Direccion,
		tel_cli = @Telefono,
		correo_elect = @Correo,
		Nombre_empresa = @NombreEmpresa,
		Ruc = @Ruc
	WHERE id_cliente = @Cedula
END;
GO
-------------------------------Buscar Empleado----------------------
CREATE PROCEDURE sp_BuscarNom_Emple
@Buscar varchar(100)
AS
BEGIN
SELECT 
PrimerNom_cli + ' ' + SegundoNom_cli + ' ' + PrimerApp_cli + ' ' + SegundoApp_cli AS 'Nombre del Cliente',
id_empleado AS Cedula,
ocupacion AS 'Ocupaci�n',
rol	AS Rol,
tel_cli AS 'Telefono Celular',
correo AS 'Correo Electronico',
dir_cli AS 'Direccion',
nomb_usuario AS 'Nombre de Usuario',
clave AS 'Clave de Usuario',
nombreSede AS 'Sede',
sueldo AS 'Sueldo'
FROM Empleados
WHERE 
(PrimerNom_cli + ' ' + SegundoNom_cli + ' ' + PrimerApp_cli + ' ' + SegundoApp_cli) LIKE @Buscar+'%' or id_empleado LIKE @Buscar +'%'
END;
---------------------------Insertar Empleado---------------------------
GO
CREATE PROCEDURE sp_InsertarEmpleado
    @Cedula varchar(10),
    @PrimerNombre varchar(25),
    @SegundoNombre varchar(25),
    @PrimerApellido varchar(25),
    @SegundoApellido varchar(25),
    @Direccion varchar(30),
    @Telefono varchar(10),
    @Correo varchar (30),
    @Rol varchar(15),
    @Ocupacion varchar(30),
    @Clave varchar(20),
    @NombreUsuario varchar(20),
    @NombreSede varchar(15),
    @Sueldo decimal(9, 2)
AS
BEGIN
    INSERT INTO Empleados (id_empleado, PrimerNom_cli, SegundoNom_cli, PrimerApp_cli, SegundoApp_cli, dir_cli, tel_cli,correo, rol, ocupacion, clave, nomb_usuario, nombreSede, sueldo)
    VALUES (@Cedula, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Direccion, @Telefono,@Correo, @Rol, @Ocupacion, @Clave, @NombreUsuario, @NombreSede, @Sueldo)
END;
----------------------------------Modificar Empleado----------------------
GO
CREATE PROCEDURE sp_ModificarEmpleado
    @Cedula varchar(10),
    @PrimerNombre varchar(25),
    @SegundoNombre varchar(25),
    @PrimerApellido varchar(25),
    @SegundoApellido varchar(25),
    @Direccion varchar(30),
    @Telefono varchar(10),
    @Correo varchar (30),
    @Rol varchar(15),
    @Ocupacion varchar(30),
    @Clave varchar(20),
    @NombreUsuario varchar(20),
    @NombreSede varchar(15),
    @Sueldo decimal(9, 2)
AS
BEGIN
    UPDATE Empleados
	SET id_empleado = @Cedula,
		PrimerNom_cli = @PrimerNombre,
		SegundoNom_cli= @SegundoNombre,
		PrimerApp_cli = @PrimerApellido,
	    SegundoApp_cli = @SegundoApellido,
		dir_cli = @Direccion,
		tel_cli = @Telefono,
		correo = @Correo,
		rol = @Rol,
		ocupacion = @Ocupacion,
		clave = @Clave,
		nomb_usuario = @NombreUsuario,
		nombreSede = @NombreSede,
		sueldo = @Sueldo
	WHERE id_empleado = @Cedula
END;
GO
---------------------------------Buscar Proveedor----------------------
CREATE PROCEDURE sp_BuscarNom_Prov
@Buscar varchar(100)
AS
BEGIN
SELECT 
nombre_prov AS 'Nombre Empresarial',
id_proveedor	AS RUC,
tel_prov AS 'Tel�fono Celular',
correo_elect AS 'Correo Electr�nico',
dir_prov AS 'Direcci�n',
nombreSede AS 'Sede'
FROM Proveedores 
WHERE 
nombre_prov LIKE @Buscar+'%' or id_proveedor LIKE @Buscar+'%'
END;
GO
--------------------------Insertar Proveedor
CREATE PROCEDURE sp_InsertarProveedor
  @RUC varchar(13),
  @NombreEmpresarial varchar(20),
  @Correo varchar(20),
  @Telefono varchar(10),
  @Direccion varchar(20),
  @NombreSede varchar(15)
AS
BEGIN
    INSERT INTO Proveedores(id_proveedor, nombre_prov, nombreSede,dir_prov,tel_prov,correo_elect)
    VALUES (@RUC, @NombreEmpresarial, @NombreSede, @Direccion, @Telefono,@Correo)
END;
GO
---------------------------Modificar Proveedor--------------------------
CREATE PROCEDURE sp_ModificarProveedor
    @Direccion varchar(30),
    @Telefono varchar(10),
    @Correo varchar (30),
    @RUC varchar (13),
    @NombreSede varchar(15),
	@NombreEmpresarial varchar (20)
AS
BEGIN
    UPDATE Proveedores
	SET   id_proveedor =@RUC,
		  nombre_prov =@NombreEmpresarial,
		  correo_elect =@Correo,
		  tel_prov = @Telefono,
		  dir_prov = @Direccion,
		  nombreSede =@NombreSede
	WHERE id_proveedor = @RUC
END;
GO
---------------------Buscar Producto-------------------------------------
CREATE PROCEDURE sp_BuscarNom_Prod
@Nombre varchar(100)
AS
BEGIN
SELECT 
    id_producto AS 'C�digo de Barra',
    nombre_prod AS 'Nombre del Producto',
    precio_porPaq AS 'Precio por Paquete',
    cant AS 'Cantidad'
FROM
    Productos
WHERE
	nombre_prod LIKE @Nombre+'%'
END;
GO
-------------------------Insertar Producto---------------------------------
CREATE PROCEDURE sp_InsertarProductos
  @NombreProducto varchar(30),
  @PrecioPaquete decimal(7, 2),
  @CodigoBarra int
AS
BEGIN
    INSERT INTO Productos(id_producto, nombre_prod, precio_porPaq)
    VALUES (@CodigoBarra, @NombreProducto, @PrecioPaquete)
END;
GO
-----------------------Modificar Producto------------------------------------
CREATE PROCEDURE sp_ModificarProducto
	  @CodigoBarra int ,
	  @NombreProducto varchar(30),
	  @PrecioPaquete decimal(7, 2)
AS
BEGIN
    UPDATE Productos
	SET   id_producto = @CodigoBarra,
		  nombre_prod = @NombreProducto,
		  precio_porPaq = @PrecioPaquete
	WHERE id_producto = @CodigoBarra
END;
GO
------------------------Buscar Compra--------------------------
CREATE PROCEDURE sp_BuscarNumOrden
@Buscar varchar(100)
AS
BEGIN
    SELECT
        noc.num_orden AS 'C�digo de Compra',
        p.nombre_prod AS 'Nombre del Producto',
        ic.id_producto AS 'C�digo de Barra',
        ic.cant AS 'Paquetes Comprados',
        noc.iva AS 'IVA',
        noc.total AS 'Costo Total',
        noc.modoPag AS 'Modo de Pago',
        noc.fecha_adq AS 'Fecha de Compra',
        prv.nombre_prov AS 'Nombre del Proveedor',
        prv.id_proveedor AS 'RUC del Proveedor'
    FROM NumeroOrdenCompra noc
    INNER JOIN ItemsC ic ON noc.num_orden = ic.num_orden
    INNER JOIN Productos p ON ic.id_producto = p.id_producto
    INNER JOIN Proveedores prv ON ic.id_proveedor = prv.id_proveedor
    WHERE 
        p.nombre_prod LIKE @Buscar + '%' 
        OR ic.id_proveedor LIKE @Buscar + '%' 
        OR prv.nombre_prov LIKE @Buscar + '%';
END;
GO
------------------------Insertar Compra---------------
CREATE PROCEDURE sp_Comprar
  @NumeroOrden int,
  @Total decimal(9, 2),
  @IVA decimal(9, 2),
  @Fecha date,
  @ModoPago varchar(30)
AS
BEGIN
    INSERT INTO NumeroOrdenCompra(num_orden, total, iva, fecha_adq,modoPag)
    VALUES (@NumeroOrden, @Total, @IVA, @Fecha, @ModoPago)
END;
GO
--------------------------------LLenar Item C--------------------------
CREATE PROCEDURE sp_ItemC
  @Cantidad int,
  @NumeroOrden int,
  @CodigoBarras int,
  @RUC varchar(13)
AS
BEGIN
    INSERT INTO ItemsC(cant, num_orden, id_producto,id_proveedor)
    VALUES (@Cantidad,@NumeroOrden, @CodigoBarras,@RUC)
END;
GO
-----------------------------Buscar Venta---------------------
CREATE PROCEDURE sp_BuscarNumFact
@Buscar varchar(100)
AS
BEGIN
    SELECT
        fv.num_factura AS 'C�digo de Venta',
        fv.id_cliente AS 'Cedula del Cliente',
        p.nombre_prod AS 'Nombre del Producto',
        iv.id_producto AS 'C�digo de Barra',
        iv.cant AS 'Paquetes Vendidos',
        fv.iva AS 'IVA',
        fv.total AS 'Costo Total',
        fv.modoPago AS 'Modo de Pago',
        fv.fecha_fact AS 'Fecha de Venta'
    FROM FacturasV fv
    INNER JOIN ItemsV iv ON fv.num_factura = iv.num_factura
    INNER JOIN Productos p ON iv.id_producto = p.id_producto
    WHERE 
        p.nombre_prod LIKE @Buscar + '%' 
        OR fv.id_cliente LIKE @Buscar + '%';
END;
GO
----------------------Insertar venta ------------------------------
CREATE PROCEDURE sp_Vender
  @NumeroFactura int,
  @Total decimal(9, 2),
  @IVA decimal(9, 2),
  @Fecha date,
  @CI varchar(10),
  @ModoPago varchar(30)
AS
BEGIN
    INSERT INTO FacturasV(num_factura, total,id_cliente, iva, fecha_fact,modoPago)
    VALUES (@NumeroFactura, @Total, @CI, @IVA, @Fecha, @ModoPago)
END;
GO
-------------------------Llenar Item V------------------------------------
CREATE PROCEDURE sp_ItemV
  @Cantidad int,
  @NumeroFactura int,
  @CodigoBarra int
AS
BEGIN
    INSERT INTO ItemsV(cant, num_factura, id_producto)
    VALUES (@Cantidad,@NumeroFactura, @CodigoBarra)
END;
-------------------Actualiza Cantidad de productos (Compra)----------------------
GO
CREATE PROCEDURE sp_actualizarCantProducto
    @CodigoBarra int,
    @Cantidad int
AS
BEGIN
    UPDATE Productos
    SET cant = ISNULL(cant, 0) + @Cantidad
    WHERE id_producto = @CodigoBarra;
END;
-------------------Actualiza Cantidad de productos (Venta)----------------------
GO
CREATE PROCEDURE sp_actualizarCantProductoV
    @CodigoBarra int,
    @Cantidad int
AS
BEGIN
    UPDATE Productos
    SET cant = cant - @Cantidad
    WHERE id_producto = @CodigoBarra;
END;
------------------------------Insertar Registros de Caja-------------------------
GO
CREATE PROCEDURE sp_InsertarRegistroCaja
    @CodigoCaja int,
    @Fecha date,
    @NombreUsuario varchar(20),
    @MontoInicial decimal(9, 2),
    @MontoCierre decimal (9, 2),
    @TotalTransG decimal(9, 2),
    @TotalEfectG decimal(9, 2),
    @GastosTotales decimal(9, 2),
    @TotalTransI decimal(9, 2),
    @TotalEfectI decimal(9, 2),
    @IngresosTotales decimal(9, 2)
AS
BEGIN
    INSERT INTO Caja (codigoCierreCaja, fecha, nomb_usuario, montoInicial, montoCierre, totalTransG, totalEfectG, GastosTotales, totalTransI, totalEfectI, IngresosTotales)
    VALUES (@CodigoCaja, @Fecha, @NombreUsuario, @MontoInicial, @MontoCierre, @TotalTransG, @TotalEfectG, @GastosTotales, @TotalTransI, @totalEfectI, @IngresosTotales);
END;
GO
--------------------------------Busqueda de Cajas----------------------------------
CREATE PROCEDURE sp_BuscarCaja
@fecha date
AS
BEGIN
SELECT
    C.codigoCierreCaja AS 'Codigo Caja',
    C.fecha AS 'Fecha de Cierre',
    C.nomb_usuario AS 'Usuario',
    E.id_empleado AS 'CI Usuario',
    C.totalTransG AS 'Gastos Totales en Transferencias',
    C.totalEfectG AS 'Gastos Totales en Efectivo',
    C.totalTransI AS 'Ingresos Totales en Tranferencias',
    C.totalEfectI AS 'Ingresos Totales en Efectivo',
	C.GastosTotales AS 'Gastos Totales en Compras',
	C.IngresosTotales AS 'Ingresos Totales en Ventas',
	C.montoInicial AS 'Monto Inicial',
	C.montoCierre AS 'Monto de Cierre'
    
FROM Caja C
INNER JOIN Empleados E ON C.nomb_usuario = E.nomb_usuario
WHERE fecha = @fecha
end;
--------------------------------Mostrar todas las cajas----------------------------------
GO
CREATE PROCEDURE sp_MostrarCajas
AS
BEGIN
SELECT
    C.codigoCierreCaja AS 'Codigo Caja',
    C.fecha AS 'Fecha de Cierre',
    C.nomb_usuario AS 'Usuario',
    E.id_empleado AS 'CI Usuario',
    C.totalTransG AS 'Gastos Totales en Transferencias',
    C.totalEfectG AS 'Gastos Totales en Efectivo',
    C.totalTransI AS 'Ingresos Totales en Tranferencias',
    C.totalEfectI AS 'Ingresos Totales en Efectivo',
	C.GastosTotales AS 'Gastos Totales en Compras',
	C.IngresosTotales AS 'Ingresos Totales en Ventas',
	C.montoInicial AS 'Monto Inicial',
	C.montoCierre AS 'Monto de Cierre'
    
FROM Caja C
INNER JOIN Empleados E ON C.nomb_usuario = E.nomb_usuario
end;

