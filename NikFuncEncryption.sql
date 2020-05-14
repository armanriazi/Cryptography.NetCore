USE [SemOperationWebService]
GO

/****** Object:  UserDefinedFunction [dbo].[NikFuncEncryption]    Script Date: 5/15/2019 4:09:58 PM ******/
--SET ANSI_NULLS OFF
--GO

--SET QUOTED_IDENTIFIER OFF
--GO

CREATE FUNCTION [dbo].[NikFuncEncryption](@plainTxt [nvarchar](max), @keyTxt [nvarchar](max), @ivTxt [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [NikCryptography].[NikCryptography.Encryption].[NikFuncEncryption]
GO
GO


