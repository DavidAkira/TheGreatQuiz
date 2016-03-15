var intervalID = null;

    //$(function () {
    function startTimer(startMin, startSec, finished) {
        if (intervalID != null) {
            //TODO:: kanske lägga till ett error!
            return;
        }
        $(".foot-timer").css("visibility", "visible")

        function StopWatch(startMin, startSec) {
            this.seconds = startSec;
            this.minutes = startMin;

            this.tick = function () {
                this.seconds--;
                if (this.seconds <= 0) {

                    this.minutes--;
                    if (this.minutes < 0) {
                        this.minutes = 0;
                        return true;
                    }
                    this.seconds = 59;
                };
            };
        };

        var tmpWatch = new StopWatch(startMin, startSec);

        tick();
        IntervalID = setInterval(tick, 1000);

        function tick() {
            var isOver = tmpWatch.tick();

            if (isOver) {
                //clearInterval(IntervalID);
                finished();
            }

            $(".foot-timer").text(tmpWatch.minutes + ":" + tmpWatch.seconds);
        }
    }

    function stopTimer() {
        clearInterval(IntervalID);
        $(".foor-timer").css("visibility", "hidden");
        intervalID = null;
}