USE [SemOperationWebService]
GO
--, @encrypted nvarchar(max) out, @extractedIVTxt nvarchar(max) out, @error nvarchar(max) out
CREATE FUNCTION [dbo].[NikFuncEncryptionMain](@plainTxt [nvarchar](max))
 RETURNS  nvarchar(max) 
 WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [NikCryptographyMain].[NikCryptographyMain.Encryption].[NikFuncEncryptionMain]
GO

CREATE FUNCTION [dbo].[NikFuncDecryptionMain](@encrypted [nvarchar](max), @keyTxt [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [NikCryptographyMain].[NikCryptographyMain.Decryption].[NikFuncDecryptionMain]
GO
