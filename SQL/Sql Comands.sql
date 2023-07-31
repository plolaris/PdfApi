--========================================================================================================================
-- Create Table
--========================================================================================================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_PDF]') AND type in (N'U'))
DROP TABLE [dbo].[TB_PDF]
GO
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_PDF](
	[pdf_ID] [int] IDENTITY(1,1) NOT NULL,
	[pdf_Name] [nvarchar](150) NULL,
	[pdf_Content] [varbinary](max) NULL,
 CONSTRAINT [PK_TB_PDF] PRIMARY KEY CLUSTERED 
(
	[pdf_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--========================================================================================================================
-- Insert values from local storage
--========================================================================================================================
DECLARE @pdf VARBINARY(MAX)
declare @docName nvarchar(150) = 'PDF 10.pdf'
SELECT @pdf = BulkColumn
FROM OPENROWSET(BULK N'C:\Users\userName\Desktop\PDFs\PDF 10.pdf', SINGLE_BLOB) AS Document;

SELECT @docName,@pdf 
 

insert into TB_PDF (pdf_Name, pdf_Content)
SELECT @docName,@pdf 

--========================================================================================================================
-- Selects
--========================================================================================================================
select *
from TB_PDF (nolock)

-- Select string as base64
select top 1 ColumnToSwFinalResult
from TB_PDF
cross apply (select pdf_Content '*' for xml path('')) T (ColumnToSwFinalResult)
--========================================================================================================================
-- sp_PDF_Get
--========================================================================================================================
CREATE PROCEDURE [dbo].[sp_PDF_Get]
	@Id int
AS
begin
	select pdf_ID, pdf_Name, pdf_Content
	from dbo.[TB_PDF]
	where pdf_ID = @Id;
end
--========================================================================================================================
-- sp_PDF_GetAll
--========================================================================================================================
CREATE PROCEDURE [dbo].[sp_PDF_GetAll]
AS
begin
	select pdf_ID, pdf_Name, pdf_Content
	from dbo.[TB_PDF];
end
