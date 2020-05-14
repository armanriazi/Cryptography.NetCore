USE [SemOperationWebService]
GO
--, @encrypted nvarchar(max) out, @extractedIVTxt nvarchar(max) out, @error nvarchar(max) out
CREATE FUNCTION [dbo].[FuncEncryptionMain](@plainTxt [nvarchar](max))
 RETURNS  nvarchar(max) 
 WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [CryptographyMain].[CryptographyMain.Encryption].[FuncEncryptionMain]
GO

CREATE FUNCTION [dbo].[FuncDecryptionMain](@encrypted [nvarchar](max), @keyTxt [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [CryptographyMain].[CryptographyMain.Decryption].[FuncDecryptionMain]
GO
