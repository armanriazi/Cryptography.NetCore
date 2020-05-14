USE [SemOperationWebService]
GO

/****** Object:  UserDefinedFunction [dbo].[NikFuncDecryption]    Script Date: 5/15/2019 4:09:35 PM ******/
--SET ANSI_NULLS OFF
--GO

--SET QUOTED_IDENTIFIER OFF
--GO

CREATE FUNCTION [dbo].[NikFuncDecryption](@cipherTxt [nvarchar](max), @keyTxt [nvarchar](max), @ivTxt [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [NikCryptography].[NikCryptography.Decryption].[NikFuncDecryption]
GO


