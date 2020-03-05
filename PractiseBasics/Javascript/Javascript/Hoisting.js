(function () {
    f();
    f = function () { console.log(1); };
})();
function f() { console.log(2); }
f(); // Write output: 

//2 function declaration function f() hoisted in global scope then function expression hoisted on global first printed 2 at the line 2 call
//1 global hoistef replace with the value of 1 i.e line 3 so printed 1 on call of 6
//undefined iify function