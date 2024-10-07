USE [SampleAPI]
GO

/****** Object:  Table [dbo].[SurveyParticipants]    Script Date: 10/7/2024 4:06:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurveyParticipants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SurveyId] [int] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_SurveyParticipant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SurveyParticipants]  WITH CHECK ADD  CONSTRAINT [FK_SurveyParticipant_Survey] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([Id])
GO

ALTER TABLE [dbo].[SurveyParticipants] CHECK CONSTRAINT [FK_SurveyParticipant_Survey]
GO


