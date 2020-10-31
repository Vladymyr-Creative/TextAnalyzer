$(document).ready(function () {
    var analyzerList = $("#analyzerList input[type=checkbox]");
    analyzerList.each(function () {
        var name = $(this).attr("name");
        var handleInputs = function () {
            var inputAnalyzer = $(this).siblings("[type=hidden]").first();
            if ($("input[name=" + name + "]:checked").length === 1) {
                console.log(name + " checked");
                inputAnalyzer.val(name);
            } else {
                console.log(name + " unchecked");
                inputAnalyzer.val("");
            }
        }.bind(this);

        handleInputs();

        $(this).on("click", handleInputs);
    });
});