using Emgu.CV.Structure;
using IAR.Database;
using IAR.Exception;
using IAR.Image;
using Npgsql;

namespace IAR.Game
{
    public class Match
    {
        private Team _team1;

        public Team Team1
        {
            get { return _team1; }
            set { _team1.players = value.players; }
        }

        private Team _team2;

        public Team Team2
        {
            get { return _team2; }
            set { _team2.players = value.players; }
        }

        public Movable Ball;

        public Match(Team team1, Team team2, Movable ball, List<LineSegment2D> lines)
        {
            this._team1 = team1;
            this._team2 = team2;
            this.Ball = ball;
            this.setDirection(lines);
        }

        public void Save()
        {
            NpgsqlConnection connection = DatabaseManager.GetConnection();
            connection.Open();
            try
            {
                this._team1.setIdTeamByName(connection);
                this._team2.setIdTeamByName(connection);
                DatabaseManager.Execute(
                    $"insert into game(id_insider,id_outsider,score_outsider,score_insider) values({this._team1.Id},{this._team2.Id},{this._team1.point},{this._team2.point})",connection);
            }
            catch (TeamNameNotFoundException ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Next(ImageTraitement traitementImage)
        {
            if (this._team1.teamName == "Red")
            {
                this.Team1.players = traitementImage.GetRedPlayers();
                this.Team2.players = traitementImage.GetBluePlayers();
            }
            else
            {
                this.Team1.players = traitementImage.GetBluePlayers();
                this.Team2.players = traitementImage.GetRedPlayers();
            }

            this.Ball = traitementImage.GetBlackBall();
            this.setDirection(traitementImage.GetLines());
        }

        protected void setDirection(List<LineSegment2D> lines)
        {
            Movable minY = null;
            Movable maxY = null;
            int valueMinY = 9999999;
            int valueMaxY = 0;
            foreach (var player in _team1.players)
            {
                if (valueMinY > player.centerPoint.Y)
                {
                    valueMinY = player.centerPoint.Y;
                    minY = player;
                }

                if (valueMaxY < player.centerPoint.Y)
                {
                    valueMaxY = player.centerPoint.Y;
                    maxY = player;
                }
            }

            foreach (var player in Team2.players)
            {
                if (valueMinY > player.centerPoint.Y)
                {
                    valueMinY = player.centerPoint.Y;
                    minY = player;
                }

                if (valueMaxY < player.centerPoint.Y)
                {
                    valueMaxY = player.centerPoint.Y;
                    maxY = player;
                }
            }

            if (Team1.players.Contains(minY))
            {
                Team1.setAttackingUp(false, lines);
                Team2.setAttackingUp(true, lines);
                return;
            }

            Team1.setAttackingUp(true, lines);
            Team2.setAttackingUp(false, lines);
        }

        public void SetPointTeam()
        {
            if (this.Team1.LostAPoint(this.Ball))
            {
                Console.WriteLine(@"But!!!!!");
                this.Team2.point++;
            }

            if (this.Team2.LostAPoint(this.Ball))
            {
                Console.WriteLine(@"But!!!!!");
                this.Team1.point++;
            }
        }

        public bool IsPlayerLeadingOffside()
        {
            Team teamLeading = this.GetTeamLeadingTheBall();
            Movable playerLeading = teamLeading.GetPlayerNearestBall(this.Ball);
            Movable beforeLastDefender = GetOpponentTeam(teamLeading).GetBeforeLastDefender();
            if (teamLeading.AttackingUp)
            {
                if (playerLeading.GetFrontPoint().Y < beforeLastDefender.GetBackPoint().Y)
                {
                    return true;
                }
            }
            else
            {
                if (playerLeading.GetFrontPoint().Y > beforeLastDefender.GetBackPoint().Y)
                {
                    return true;
                }
            }

            return false;
        }

        public Team GetTeamLeadingTheBall()
        {
            double closest = 9999999999d;
            foreach (Movable player1 in _team1.players)
            {
                double distance = Math.Sqrt(Math.Pow(Ball.centerPoint.X - player1.centerPoint.X, 2) +
                                            Math.Pow(Ball.centerPoint.Y - player1.centerPoint.Y, 2));
                if (distance < closest)
                {
                    closest = distance;
                }
            }

            foreach (Movable player2 in Team2.players)
            {
                double distance = Math.Sqrt(Math.Pow(Ball.centerPoint.X - player2.centerPoint.X, 2) +
                                            Math.Pow(Ball.centerPoint.Y - player2.centerPoint.Y, 2));
                if (distance < closest)
                {
                    closest = distance;
                    return Team2;
                }
            }

            return Team1;
        }

        public Team GetOpponentTeam(Team team)
        {
            if (team == this.Team1)
            {
                return Team2;
            }

            return this.Team1;
        }

        public Movable GetBeforeLastDefender()
        {
            Team teamLeadingTheBall = GetTeamLeadingTheBall();
            Team opposingTeam = GetOpponentTeam(teamLeadingTheBall);
            return opposingTeam.GetBeforeLastDefender();
        }

        public List<Movable> GetPlayerOffside()
        {
            Team teamLeadingTheBall = GetTeamLeadingTheBall();
            Team opposingTeam = GetOpponentTeam(teamLeadingTheBall);
            Movable beforeLastDefender = opposingTeam.GetBeforeLastDefender();
            List<Movable> players = new List<Movable>();
            Movable playerLeadingBall = teamLeadingTheBall.GetPlayerNearestBall(this.Ball);
            foreach (Movable player in teamLeadingTheBall.players)
            {
                if (teamLeadingTheBall.AttackingUp)
                {
                    if (playerLeadingBall != player && player.GetFrontPoint().Y < beforeLastDefender.GetBackPoint().Y &&
                        player.GetFrontPoint().Y < Ball.centerPoint.Y)
                    {
                        players.Add(player);
                    }
                }
                else
                {
                    if (playerLeadingBall != player && player.GetFrontPoint().Y > beforeLastDefender.GetBackPoint().Y &&
                        player.GetFrontPoint().Y > Ball.centerPoint.Y)
                    {
                        players.Add(player);
                    }
                }
            }

            return players;
        }
    }
}