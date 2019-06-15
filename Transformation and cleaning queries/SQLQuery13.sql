create table demotable(
libname nvarchar(50),
creationDate datetime,
updateDate datetime,
questionDate datetime
)

insert into demotable
(libname,creationDate,updatedate,questiondate)
VALUES ('abc',
null,
null,
'2019-05-08');


create view questionsperday3 as
select count(questiondate) as totalCount,questiondate
from dbo.demotable 
where questiondate is not null
group by questiondate,libname

select * from questionsperday2

select * from demotable order by 

select* from  updatesperday,questionsperday

select * from demotable

create view mergedDates2 as
select count(questiondate) as questionCount,questiondate,count(updatedate) as updatecount,updatedate
from dbo.demotable 
group by questiondate,updatedate,libname

select * from mergedDates3

select questiondate as [date],updatedate as [date] from mergeddates2 where questiondate


select questiondate into dbo.mergedDates3 from dbo.mergeddates2 where questiondate is not null
 
insert into dbo.mergeddates3
select distinct updatedate from dbo.mergeddates2 where updatedate is not null

select distinct questiondate
into dbo.mergeddates4
from mergeddates3

select * from dbo.mergeddates4

alter table dbo.mergeddates4
add updatecount int

update dbo.mergeddates4  set questioncount = 2
where questiondate='2019-05-08'

select * from mergeddates4 order by questiondate

select * from dbo.mergeddates4 order by qu

