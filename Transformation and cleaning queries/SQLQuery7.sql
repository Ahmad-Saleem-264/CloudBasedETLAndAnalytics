select count(*) from Repositories

select count(*) from StackQuestions

select top 10 * from StackQuestions

select top 10 * from repositories where RepoName like '%mongo%' order by starscount desc where RepoId=12981

select top 10 * from repositories order by starscount desc


select count(*) from [Version_Join]



select count(*) from Repositories 
inner join StackQuestions
on StackQuestions.Tags like '%'+Repositories.RepoName+'%'
order by starsCount desc

select top 10 * from StackQuestions



select count(*) from Repositories 
inner join StackQuestions
on StackQuestions.Tags=Repositories.RepoName


SELECT * FROM STRING_SPLIT('Lorem,ipsum,dolor,sit,amet.', ',')


select top 100 * from Repositories 
inner join 
( select * from stackQuestions
CROSS APPLY STRING_SPLIT(Tags, '|')
) temp

on Repositories.repoName=temp.value



select top 10 * from stackQuestions
CROSS APPLY STRING_SPLIT(Tags, '|') 


select count(*) from dbo.newversion_join where repoid=0

select count(*) from repositories

select count(*) from stackquestions

select count(*),RepoName from repositories 
group by RepoName having count(*)>1 order by COUNT(*) desc


select * into #tempCount from (
select count(*) as countt from repositories 
group by RepoName having count(*)>1 
) as tt 

select sum(countt) from #tempCount
 
 












select sum(
select 3
)

select * FROM Repositories
WHERE RepoId Not IN
(
SELECT top 10 MIN(RepoId),RepoName
FROM Repositories
GROUP BY RepoName
)
order by RepoName

select * from Repositories where RepoName='12306' order by starscount desc offset (1) ROWS FETCH NEXT (7) ROWS ONLY


SELECT top 10 MIN(RepoId),RepoName
FROM Repositories
GROUP BY RepoName

select * from repositories where repoName=temp.reponame



select Max(starsCount),repoName
FROM Repositories
where reponame='12306'
GROUP BY RepoName
order by RepoName


select * from repositories
left join (select Max(starsCount) starsCount,repoName
FROM Repositories
where reponame='12306'
GROUP BY RepoName) temp
on Repositories.RepoName=temp.RepoName
and Repositories.starsCount!=temp.starsCount
where Repositories.reponame='12306' and temp.repoName is not null






