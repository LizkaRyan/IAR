namespace IAR.Exception;
using System;

public class TeamNameNotFoundException(string teamName) : Exception($"The {teamName} team was not found.");