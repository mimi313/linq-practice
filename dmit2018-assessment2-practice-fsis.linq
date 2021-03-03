<Query Kind="Statements">
  <Connection>
    <ID>40609a24-d1c8-4ac0-b143-7c9ae3f3d6f5</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>BABYSHARK\SQLEXPRESS</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>FSIS_2018</Database>
  </Connection>
</Query>

//List all the players who haven't played a game
from x in Players
where x.PlayerStats.Count() > 0
select x

//Show a team that has the max number of losses
from x in Teams
where x.Losses == (from y in Teams
					select y.Losses).Max()
select new 
	{
	TeamName = x.TeamName,
	NumOfLosses = (from y in Teams
					select y.Losses).Max()
	}
	
//List players who has gotten RedCard
from x in PlayerStats
where x.RedCard == true
select x.Player.FirstName + " " + x.Player.LastName

//List parents who have the greatest number of kids
var test = from x in Guardians
select new 
	{
		Name = x.FirstName + " " + x.LastName,
		NumOfKids = x.Players.Count()
	};

var kids = from y in test
			where y.NumOfKids == test.Max(y => y.NumOfKids)
			select y;
kids.Dump();



//Show players who has nut allergies
from x in Players
where x.MedicalAlertDetails.Contains("nut")
select x.FirstName + " " + x.LastName


//Guardians who don't have a kid
from x in Guardians
where x.Players.Count() ==  0
select x







