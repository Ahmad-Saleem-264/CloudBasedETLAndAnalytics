-- select * into stackQuestionTags from stackQuestions
--CROSS APPLY STRING_SPLIT(Tags, '|')

select top 1000 * from stackQuestionTags where tags!='javascript'

select top 30 COUNT([value]) as tagCount, [value] as tag
into stackQuestionTagCount
 from stackQuestionTags
 group by [value] 
 order by COUNT([value]) desc

select top 30 COUNT([language]) as langCount, [language]
into RepoLanguageCount
 from Repositories
 
 where [language] is not null and [language]!=''
 group by [language] 
 order by COUNT([language]) desc


 select * from RepoLanguageCount
 inner join stackQuestionTagCount
 on [language]=tag