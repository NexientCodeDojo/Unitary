# Unitary

## What is Unitary?
-------------------
+ Library for handling scientific units
+ Has built-in types for all SI base units
+ Can convert between units of the same type easily
+ Can parse strings to convert them to units

## Design
---------
### Positive Aspects
+ Multiple ways to parse units
+ Unit enums have attributes to determine symbol and scaling
+ Unit attribute data is only read once, then cached
+ Conversions are easy with the conversion properties
    + For example, Time.Parse("5s").Hours
+ Excellent unit test coverage, with common testing base class
+ Reflection in unit tests ensures all types are tested

### Negative Aspects
+ Static Parse methods not enforced
+ No design for compound units
+ Interfaces are generic and require base type and matching enum
+ Reflection in unit tests?
+ Don't like depending on [Order(2)] in test coverage tests

### Future Plans
+ Make compound units easy (velocity, acceleration, force, pressure, etc)
+ Make parsing more robust with a TryParse function that guesses units
+ Simplify IUnit interface to only the enum type
