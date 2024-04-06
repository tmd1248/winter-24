using System;

class SimpleEvent: Event {
    void closeEvent() {
        _what = null;
        _people = null;
        _where = null;
    }
}