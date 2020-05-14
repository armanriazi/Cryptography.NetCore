USE [SemOperationWebService]
--create ASSEMBLY NetCoreClrOne 
--        FROM 'C:\Users\A_RIAZI\Source\repos\CLR1\CLR1\bin\Release\netcoreapp2.2\CLR1.dll' 
--        WITH PERMISSION_SET = UNSAFE ;


sp_configure 'clr enabled', 1  

alter database SemOperation set trustworthy off;
RECONFIGURE  

sp_dbcmptlevel 


sp_dbcmptlevel 'SemOperation', 140

EXEC sp_configure 'show advanced options', 1 
RECONFIGURE; 
EXEC sp_configure 'clr strict security', 0; 
RECONFIGURE;



SELECT *  
FROM sys.databases WHERE name = 'SemOperationWebService';  
GO  

RECONFIGURE