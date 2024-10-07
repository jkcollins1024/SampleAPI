USE [SampleAPI]
GO

/****** Object:  Table [dbo].[ParticipantResponses]    Script Date: 10/7/2024 4:06:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParticipantResponses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResponseText] [nvarchar](max) NULL,
	[ResponseValue] [int] NULL,
	[SurveyParticipantId] [int] NOT NULL,
	[SurveyQuestionId] [int] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_ParticpantResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ParticipantResponses]  WITH CHECK ADD  CONSTRAINT [FK_ParticipantResponse_SurveyParticipant] FOREIGN KEY([SurveyParticipantId])
REFERENCES [dbo].[SurveyParticipants] ([Id])
GO

ALTER TABLE [dbo].[ParticipantResponses] CHECK CONSTRAINT [FK_ParticipantResponse_SurveyParticipant]
GO

ALTER TABLE [dbo].[ParticipantResponses]  WITH CHECK ADD  CONSTRAINT [FK_ParticipantResponse_SurveyQuestion] FOREIGN KEY([SurveyQuestionId])
REFERENCES [dbo].[SurveyQuestions] ([Id])
GO

ALTER TABLE [dbo].[ParticipantResponses] CHECK CONSTRAINT [FK_ParticipantResponse_SurveyQuestion]
GO


