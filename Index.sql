USE [SemOperationWebService]
GO
declare @plainTxt [nvarchar](max), @keyTxt [nvarchar](max);
declare @ivTxt [nvarchar](max);
declare @cipherTxt [varchar](max);



set @plainTxt=N'ActionName_browser_computer_ClientDomainName_127.0.0.1_ClientMacAddress_ControllerName_DeviceName
_127.0.0.1_LoginMacAddressActionName_browser_computer_ClientDomainNameActionName_browser_computer_ClientDomainName
_192.0.0.1_ClientMacAddress_ControllerName_DeviceName_182.0.0.1_LoginMacAddress'

SELECT @plainTxt

SELECT @cipherTxt=[dbo].[FuncEncryptionMain] (@plainTxt) 

select top(1) value FROM STRING_SPLIT(@cipherTxt, '▲') order by value desc
select top(1) value FROM STRING_SPLIT(@cipherTxt, '▲') order by value asc


declare @keyTxt [nvarchar](max);
declare @decryptedTxt [nvarchar](max);
declare @encrypted [nvarchar](max);
set @keyTxt='811E38B3 55575E03 08107FD3 6AD1696D 839CCAF7 36734F7A B9A5437E 744FECDC' 

/*Base on values of previous execution, we have to find equivalent hash and then set as @encrypted*/

set @encrypted=N'AQEBAQEBAQAAAQEBAQABAO21UGA0lBaYS0tI/X6pekBgzGpZyRwmScEEKmQ1VK6xUP2mESlJ6h9huyhhQ8BTQvCkTvCtCjhbGNo8n1BsZSH2RsJqH/rgR4+styqD2Kct2hODHpjifwFU3czRWGmwpYsirvmCkO6iFwMrzHxfAhrvAjipKyBgKpTXHLwhfImdJZGubX+riyc+nCJze+kVxh2Wni9VDUCjRZB3ssyQLAIHXrGvYjt+VMfntyYDLT6rhVmc+qpOH3Kteb70LpB8eGSersK2g/SfXGcMxb/6R5B/H6/QArkJJLuQZVAdhCVbFfGZMf+GNpdLYOYcXgDBVmn8ojxviLWH1TG7ntHb/ZRfw7Tipz8zjz/0ZJINawrE5QRKHXwc182IfjKy9lmPHWiofUlsEL/tkWpBmarAUl8='
set @decryptedTxt=[dbo].[FuncDecryptionMain] (@encrypted,@keyTxt)
select @decryptedTxt

