using System;

class Simple_Goal : Goal  {
    public override void RecordEvent() {
        _isComplete = true;
    }
}