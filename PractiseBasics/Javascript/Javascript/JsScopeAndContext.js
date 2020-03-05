
var i = 1;
var s = "String";

(function (i) {
    var getMessage = function () {
        return this.s + ', ' + i;
    };
    var o = {
        i: i,
        s: "SomeObject",
        getMessage: getMessage
    };
    var a = {
        i: i + 1,
        s: 'More ' + s
    };
    console.log(o.getMessage());      // Write output:  "SomeObject ,0"
    console.log(getMessage());        // Write output:  "String ,0"
    console.log(getMessage.call(a));  // Write output:  "More String, 0
})(0);