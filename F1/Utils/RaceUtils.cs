using F1.Constants;
using F1.Data.DTO;

namespace F1.Utils
{
    public class RaceUtils
    {
        private static Pilots TreatCasePilotInPodium(Pilots pilot, int position)
        {
            if(position == 0)
            {
                pilot.Race_Wins += 1;
                pilot.Podiums += 1;
            }
            else if(position <= 2)
            {
                pilot.Podiums += 1;
            }

            return pilot;
        }

        public static Pilots UpdatePilotByPositionInGrid(Pilots pilot, int position)
        {
            int pointsFromRace = Race.GetPointsByPosition(position);

            pilot.Points = pilot.Points + pointsFromRace;
            pilot.Race_Entries += 1;

            pilot = TreatCasePilotInPodium(pilot, position);

            return pilot;
        }
    }
}