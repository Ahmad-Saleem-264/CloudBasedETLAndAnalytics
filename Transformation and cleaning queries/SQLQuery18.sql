 from repository_stackCopy where starscount<500 from repository_stack

select top 1000 count(StackQuestionDate) as totalCount,StackQuestionDate,libName 
from dbo.repository_stackCopy
where StackQuestionDate is not null and libname='next.js'
group by StackQuestionDate,libName
order by count(StackQuestionDate) desc



from dbo.repository_stackCopy
where 
 libName  in
(
select top 100 libName 
from dbo.repository_stackCopy
where StackQuestionDate is not null 
group by StackQuestionDate,libName
having count(StackQuestionDate)>60
)

group by StackQuestionDate,libName
having count(StackQuestionDate)>80


select top 100 libName,count(StackQuestionDate) ,StackQuestionDate
from dbo.repository_stackCopy
where StackQuestionDate is not null 
group by StackQuestionDate,libName
having count(StackQuestionDate)>80






delete from repository_stackCopy where libName='TypeScript' or libName='laravel' or libName='Objective-C' or libName='spring-boot' 



select *  from StackOverFlowTags  where tag='spring-boot'

select top 100 * from repositories where repoName='tensorflow' order by starscount desc

select top 100 * from repositories order by starscount desc

select top 30 * from stackquestions where tags like '%prettier%'


select  libName,count(StackQuestionDate) dayCount,StackQuestionDate
into repository_stackSelectedCount
from dbo.repository_stackSelected
where StackQuestionDate is not null 
group by StackQuestionDate,libName
order by count(StackQuestionDate) desc


select  libName,count(StackQuestionDate) dayCount,StackQuestionDate
into repository_stackCopyCount
from dbo.repository_stackcopy
where StackQuestionDate is not null 
group by StackQuestionDate,libName
order by count(StackQuestionDate) desc





select * from repository_stackSelectedCount order by daycount desc

select * from version_join



select * from repository_stackSelected where libName='create-react-app'  from repository_stackCopy where libname='next.js' or libname='create-react-app' or libname='yarn' or libname='bulma'
or libname='pretier'

select distinct(repoid) from repository_stackSelected

select * from version_join where repoid='11996815' 

begin transaction
commit

select * from repository_stackCopy where libName='create-react-app' 

select top 10 * from version_join



select count(versionCreatedDate) as totalCount,versionCreatedDate,Repoid 
into version_joinCount
from dbo.version_join
where Repoid is not null 
group by versionCreatedDate,Repoid
order by count(versionCreatedDate) desc


select * into version_joinSelectedCount from version_joinCount where repoid in
(
select distinct(repoid) from repository_stackSelected
)