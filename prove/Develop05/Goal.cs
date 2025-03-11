using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;
    protected bool isCompleted;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        this.isCompleted = false;
    }

    public abstract void RecordProgress();
    public abstract string GetStatus();
    public virtual int GetPoints() => points;
}
