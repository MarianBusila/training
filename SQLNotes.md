## Notes

- IF(condition, value_true, value_false) - evaluates condition

- COALESCE(val1, val2, .., valn) - return first non null

- IFNULL(expression, alt_value)

- NULLIF(expr1, expr2) - return null if 2 expressions are equal, otherwise returns expr1

- switch expresssion:
CASE
	WHEN condition1 THEN result1
	WHEN condition2 THEN result2
	ELSE resultn
END

- CAST(value as _datatype_)

- ADDDATE(date, INTERVAL value _unit_)

- SUBDATE(date, INTERVAL value _unit_)

- CTE
WITH CTE1
AS
(SELECT ...)
CTE2
AS
(SELECT ...)

- Rank and dense rank
DENSE_RANK() OVER(
[PARTITION BY columnX, ...]
ORDER BY columnY [ASC/DESC])

- Lag - allow access to a value stored above the current row
LAG(column [, offset [, defaultValue]])
OVER ORDER BY columns

- Lead - allow access to a value stored below the current row
LEAD(column [, offset [, defaultValue]])
OVER ORDER BY columns
