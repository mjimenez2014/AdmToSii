DROP TABLE IF EXISTS "main"."empresa";
CREATE TABLE "empresa" ("RutEmisor" VARCHAR(10),"RznSoc" VARCHAR(255),"GiroEmis" VARCHAR(255),"Telefono" VARCHAR(255),"CorreoEmisor" VARCHAR(255),"Acteco" VARCHAR(50),"CdgSIISucur" VARCHAR(50),"DirMatriz" VARCHAR(255),"CiudadOrigen" VARCHAR(255),"CmnaOrigen" VARCHAR(255),"DirOrigen" VARCHAR(255),"SucurSII" VARCHAR(100),"NomCertificado" VARCHAR(255),"SucurEmisor" VARCHAR(255),"FchResol" VARCHAR(50),"RutCertificado" VARCHAR(10),"NumResol" VARCHAR(20),"CondEntrega" VARCHAR(10),"UrlCore" VARCHAR(255), "PrnTwoCopy" VARCHAR(5) DEFAULT 'True', "PrnMtoNeto" VARCHAR(5) DEFAULT 'False', "PrnThermal" VARCHAR(5) DEFAULT 'True', "prnOC" VARCHAR(5), "DirLocal" VARCHAR(255));
#Iat
DROP TABLE IF EXISTS "main"."tipotraslado";
CREATE TABLE "tipotraslado" ("id" INTEGER, "nombre" TEXT);
INSERT INTO "main"."tipotraslado" VALUES (1, 'Operación constituye venta');
INSERT INTO "main"."tipotraslado" VALUES (2, 'Ventas por efectuar');
INSERT INTO "main"."tipotraslado" VALUES (3, 'Consignaciones');
INSERT INTO "main"."tipotraslado" VALUES (4, 'Entrega gratuita');
INSERT INTO "main"."tipotraslado" VALUES (5, 'Traslados internos');
INSERT INTO "main"."tipotraslado" VALUES (6, 'Otros traslados no venta');
INSERT INTO "main"."tipotraslado" VALUES (7, 'Guía de devolución');
INSERT INTO "main"."tipotraslado" VALUES (8, 'Traslado para exportación. (no venta)');
INSERT INTO "main"."tipotraslado" VALUES (9, 'Venta para exportación');
#AdmToSii
CREATE TABLE "envio" ("id" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , "tipoDte" INTEGER, "folio" INTEGER, "fchEmis" DATETIME, "mntTotal" INTEGER, "estado" VARCHAR(255), "envioXml" VARCHAR(2000), "recepcionDteXml" VARCHAR(1000), "trackId" CHAR(255))
#Tabla impuestos
DROP TABLE IF EXISTS "impuestos";
CREATE TABLE "impuestos"("id" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL, "codigosii" INTEGER, "nombre" VARCHAR(255) , tasa DOUBLE);
INSERT INTO "impuestos" (codigosii,nombre) VALUES (14,'IVA de margen de comercialización');
INSERT INTO "impuestos" (codigosii,nombre) VALUES (15,'IVA retenido total');
INSERT INTO "impuestos" (codigosii,nombre) VALUES (17,'IVA ANTICIPADO FAENAMIENTO CARNE');
INSERT INTO "impuestos" (codigosii,nombre,tasa) VALUES (18,'IVA ANTICIPADO CARNE',5);
INSERT INTO "impuestos" (codigosii,nombre,tasa) VALUES (19,'IVA ANTICIPADO HARINA',12);
INSERT INTO "impuestos" (codigosii,nombre,tasa) VALUES (23,'IMPUESTO ADICIONAL',15);
# Agrega columna 
alter table documento add column tipoimp varchar(3);
alter table documento add column tasaimp integer;
alter table documento add column montoimp integer;
#IAT
alter TABLE empresa  add column PrnThermal VARCHAR(5); 
alter TABLE empresa  add column UrlCore VARCHAR(255); 
alter TABLE empresa  add column PrnOC VARCHAR(5);
alter TABLE empresa  add column VistaPrevia VARCHAR(5);
alter TABLE empresa  add column DirLocal VARCHAR(255);
alter table reenvio add column  filefactura VARCHAR(255);

DROP TABLE IF EXISTS "main"."printers";
CREATE TABLE printers (printername VARCHAR(255), directory VARCHAR(255));
INSERT INTO "main"."printers" VALUES ('prnPdf', 'C:/IatFiles/cajas/caj1');









