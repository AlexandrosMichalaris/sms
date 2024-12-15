# sms
## VivaWallet assesment

A service needs to be created that handles SMS sending.

 

Due to cost management reasons there are three different vendors that can accomplish this operation.

 

Vendors:

All SMS sent to Greek numbers should use the vendor SMSVendorGR

All SMS sent to Cypriot numbers should use the vendor SMSVendorCY

All SMS sent to other country numbers should use the vendor SMSVendorRest

All vendors support a Send method which actually persists the messages to the db (MSSQL database)

 

Limitations:

Vendor SMSVendorGR can only handle SMS text ONLY in Greek characters

Vendor SMSVendorCY can send an SMS up to 160 characters. So logic has to be created to handle scenarios that will split the message in multiple SMS if that limitations is reached.

All Vendors (inclusive the above) could not send an SMS with greater than 480 characters

An API should be created which maps the api public request to the internal request that SMS Service handles.



What to use:

C# language
.NET 6 Minimal API Framework

Dependency injection

MSSQL as storage / Postgres ( create a simple relational DB schema to save the SMS request )

Entity

Repository Pattern

SOLID principles

KISS principle

Clean Architecture

For the vendor selection using the appropriate Design Pattern ( IF or SWITCH statements should not be used )
