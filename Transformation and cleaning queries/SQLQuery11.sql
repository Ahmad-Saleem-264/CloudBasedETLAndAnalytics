select * from Table_1
inner join Table_2
on column2 in STRING_SPLIT(column1, ',')


select * from Table_2 where column2 in ('asd')

STRING_SPLIT('asd,weq,qwe', ',')

select * from STRING_SPLIT('Lorem,ipsum,dolor,sit,amet.', ',')

select * from STRING_SPLIT(Table_1.column1,',')  

select * from Table_2 where column2 in (select value from table_1
CROSS APPLY STRING_SPLIT(column1, ',') )

select value from table_1
CROSS APPLY STRING_SPLIT(column1, ','); 


select id from table_1 





select * from Table_2
 inner join
 (select value,id from table_1
CROSS APPLY STRING_SPLIT(column1, ',') ) as a
 on column2 =a.value
 

 select * from table_1
CROSS APPLY STRING_SPLIT(column1, ',')


