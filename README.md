# HG.Puter

Putting similar properties from the source object into the destination object.

How to use:
```
var obj_1 = new Class1
{
    a = null,
    b = "2",
    c = "3",
    d = "4"
};
var obj_2 = new Class2
{
    a = 1000,
    b = "2000"
};
obj_1.Put(obj_2);
// obj_1 is:  {a="1000", b="2000", c="3", d="4"}
```
