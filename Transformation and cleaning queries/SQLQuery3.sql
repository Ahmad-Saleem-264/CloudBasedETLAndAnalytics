select * from dbo.QuestionDates

select * from dbo.popularview 

select * from dbo.questionView 

create view questionCount as
select count(StackQuestionDate) as totalCount,StackQuestionDate,libName 
from dbo.QuestionDates
where StackQuestionDate is not null
group by StackQuestionDate,libName


create view questionUpdateCount as
select count(StackQuestionDate) as totalCount,StackQuestionDate,libName 
from dbo.QuestionDates
where StackQuestionDate is not null
group by StackQuestionDate,libName
