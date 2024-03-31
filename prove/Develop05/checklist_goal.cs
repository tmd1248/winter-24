using System;

class Checklist_Goal : Goal  {
    private int _amountCompleted = 0;

    public int amountCompleted {
        get {return _amountCompleted;}
        set {_amountCompleted = value;}
    }
    private int _target;

    public int target {
        get {return _target;}
        set {_target = value;}
    }
    private int _bonus;

    public int bonus {
        get {return _bonus;}
        set {_bonus = value;}
    }

    public override void RecordEvent() {
        _amountCompleted += 1;
        if(_amountCompleted > _target) {
            _bonus += 1;
        }
    }
}