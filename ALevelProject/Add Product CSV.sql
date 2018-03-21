BULK
INSERT Stores
FROM 'C:\Users\Josh\Downloads\test data - Sheet3.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO