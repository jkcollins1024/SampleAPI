insert into dbo.Surveys (Name, Description, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Survey 1', 'Survey 1 Description', 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 1', 'Question 1 Description', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 2', 'Question 2 Description', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 3', 'Question 3 Description', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 4', 'Question 4 Description', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 5', 'Question 5 Description', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.SurveyParticipants (Name, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Participant 1', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.SurveyParticipants (Name, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Participant 2', 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 1 Response Text', 3, 1, 1, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 2 Response Text', 4, 1, 2, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 3 Response Text', 5, 1, 3, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 4 Response Text', 4, 1, 4, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 5 Response Text', 1, 1, 5, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.Surveys (Name, Description, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Survey 2', 'Survey 2 Description', 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 1 Survey 2', 'Question 1 Description', 2, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.SurveyQuestions (Title, Description, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 2 Survey 2', 'Question 2 Description', 2, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.SurveyParticipants (Name, SurveyId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Participant 1 Survey 2', 2, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());

insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 1 Response Text', 2, 3, 6, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());
insert into dbo.ParticipantResponses (ResponseText, ResponseValue, SurveyParticipantId, SurveyQuestionId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) values ('Question 2 Response Text', 2, 3, 7, 1, SYSDATETIMEOFFSET(), 1, SYSDATETIMEOFFSET());