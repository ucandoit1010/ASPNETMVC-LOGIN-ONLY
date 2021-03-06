USE [Test0314]
GO
/****** Object:  StoredProcedure [dbo].[CreateMember]    Script Date: 2018/3/14 下午 03:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateMember]
	@MemberId uniqueidentifier ,@Account varchar(50) , @Pwd varchar(80)
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Members]([MemberId],[Account],[Password])
     VALUES
           (@MemberId
		   ,@Account
           ,@Pwd);
END

GO
/****** Object:  StoredProcedure [dbo].[GetMember]    Script Date: 2018/3/14 下午 03:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMember]
	@Account varchar(50) , @Pwd varchar(80)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT MemberId , Account , [Password] FROM Members WHERE Account = @Account AND [Password] = @Pwd;

END

GO
/****** Object:  StoredProcedure [dbo].[IsMemberExists]    Script Date: 2018/3/14 下午 03:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IsMemberExists]
	@Account varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Account FROM Members WHERE Account = @Account;
END

GO
/****** Object:  Table [dbo].[Members]    Script Date: 2018/3/14 下午 03:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [uniqueidentifier] NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](80) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [DF_Members_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
