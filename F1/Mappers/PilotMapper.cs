using F1.Data.DTO;

namespace F1.Mappers
{
    public class PilotMapper
    {
        public static Pilots GetPilotInformationFromNewPilotDto(NewPilotDto newPilotDto)
        {
            return new Pilots {
                Name = newPilotDto.Name,
                Nationality = newPilotDto.Nationality,
                F2_Champion = newPilotDto.F2_Champion,
                Championships = 0,
                Race_Entries = 0,
                Race_Starts = 0,
                Pole_Positions = 0,
                Race_Wins = 0,
                Podiums = 0,
                Fastest_Laps = 0,
                Points = 0,
                Active = true,
                Champion = false,
                Pole_Rate = 0,
                Points_Per_Entry = 0,
                Years_Active = "1"
            };
        }
    }
}