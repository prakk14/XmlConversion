using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    public Utils()
    { }
    
    public static bool IsEmptyString(string str)
    {
        if (str == null || str == String.Empty)
            return true;
        return false;
    }

    public static bool IsEmptyString(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return true;
        if (obj.ToString() == String.Empty)
            return true;
        return false;
    }

    public static string ToString(string str)
    {
        if (str == null)
            return String.Empty;
        return str;
    }

    public static string ToString(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return String.Empty;
        return obj.ToString();
    }

    public static object ToDBString(string str)
    {
        if (str == null)
            return DBNull.Value;
        if (str == String.Empty)
            return DBNull.Value;
        return str;
    }

    public static object ToDBString(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        string str = obj.ToString();
        if (str == String.Empty)
            return DBNull.Value;
        return str;
    }

    public static byte[] ToBinary(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return new byte[0];
        return (byte[])obj;
    }

    public static object ToDBBinary(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        return obj;
    }

    public static object ToDBBinary(byte[] aby)
    {
        if (aby == null)
            return DBNull.Value;
        else if (aby.Length == 0)
            return DBNull.Value;
        return aby;
    }

    public static DateTime ToDateTime(DateTime dt)
    {
        return dt;
    }

    public static DateTime ToDateTime(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DateTime.MinValue;
        // If datatype is DateTime, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.DateTime"))
            return Convert.ToDateTime(obj);
        if (!IsDate(obj))
            return DateTime.MinValue;
        return Convert.ToDateTime(obj);
    }

    public static string ToDateString(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return String.Empty;
        // If datatype is DateTime, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.DateTime"))
            return Convert.ToDateTime(obj).ToString();
        if (!IsDate(obj))
            return String.Empty;
        return Convert.ToDateTime(obj).ToString();
    }

    public static string ToString(DateTime dt)
    {
        // If datatype is DateTime, then nothing else is necessary. 
        if (dt == DateTime.MinValue)
            return String.Empty;
        return dt.ToString();
    }

    public static string ToDateString(DateTime dt)
    {
        // If datatype is DateTime, then nothing else is necessary. 
        if (dt == DateTime.MinValue)
            return String.Empty;
        //return dt.ToShortDateString();
        return dt.ToString();
    }

    public static string ToTimeString(DateTime dt)
    {
        // If datatype is DateTime, then nothing else is necessary. 
        if (dt == DateTime.MinValue)
            return String.Empty;
        return dt.ToShortTimeString();
    }

    public static object ToDBDateTime(DateTime dt)
    {
        if (dt == DateTime.MinValue)
            return DBNull.Value;
        return dt;
    }

    public static object ToDBDateTime(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        if (!IsDate(obj))
            return DBNull.Value;
        DateTime dt = Convert.ToDateTime(obj);
        if (dt == DateTime.MinValue)
            return DBNull.Value;
        return dt;
    }




    public static Int32 ToInteger(Int32 n)
    {
        return n;
    }

    public static Int32 ToInteger(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return 0;
        // If datatype is Integer, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Int32"))
            return Convert.ToInt32(obj);
        else if (obj.GetType() == Type.GetType("System.Boolean"))
            return (Int32)(Convert.ToBoolean(obj) ? 1 : 0);
        else if (obj.GetType() == Type.GetType("System.Single"))
            return Convert.ToInt32(Math.Floor((System.Single)obj));
        string str = obj.ToString();
        if (str == String.Empty)
            return 0;
        return Int32.Parse(str);
    }

    public static long ToLong(long n)
    {
        return n;
    }

    public static long ToLong(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return 0;
        // If datatype is Integer, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Int64"))
            return Convert.ToInt64(obj);
        string str = obj.ToString();
        if (str == String.Empty)
            return 0;
        return Int64.Parse(str);
    }

    public static short ToShort(short n)
    {
        return n;
    }

    public static short ToShort(int n)
    {
        return (short)n;
    }

    public static short ToShort(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return 0;
        if (obj.GetType() == Type.GetType("System.Int32") || obj.GetType() == Type.GetType("System.Int16"))
            return Convert.ToInt16(obj);
        string str = obj.ToString();
        if (str == String.Empty)
            return 0;
        return Int16.Parse(str);
    }

    public static object ToDBInteger(Int32 n)
    {
        return n;
    }

    public static object ToDBInteger(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        // If datatype is Integer, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Int32"))
            return obj;
        string str = obj.ToString();
        if (str == String.Empty || !IsNumeric(str))
            return DBNull.Value;
        return Int32.Parse(str);
    }


    public static float ToFloat(float f)
    {
        return f;
    }

    public static float ToFloat(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return 0;
        // If datatype is Double, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Double"))
            return (float)Convert.ToSingle(obj);
        string str = obj.ToString();
        if (str == String.Empty || !IsNumeric(str))
            return 0;
        return float.Parse(str);
    }

    public static float ToFloat(string str)
    {
        if (str == null)
            return 0;
        if (str == String.Empty || !IsNumeric(str))
            return 0;
        return float.Parse(str);
    }

    public static object ToDBFloat(float f)
    {
        return f;
    }

    public static object ToDBFloat(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        // If datatype is Double, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Double"))
            return obj;
        string str = obj.ToString();
        if (str == String.Empty || !IsNumeric(str))
            return DBNull.Value;
        return float.Parse(str);
    }


    public static double ToDouble(double d)
    {
        return d;
    }

    public static double ToDouble(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return 0;
        // If datatype is Double, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Double"))
            return Convert.ToDouble(obj);
        string str = obj.ToString();
        if (str == String.Empty || !IsNumeric(str))
            return 0;
        return double.Parse(str);
    }

    public static double ToDouble(string str)
    {
        if (str == null)
            return 0;
        if (str == String.Empty || !IsNumeric(str))
            return 0;
        return double.Parse(str);
    }


    public static Decimal ToDecimal(Decimal d)
    {
        return d;
    }

    public static Decimal ToDecimal(double d)
    {
        return Convert.ToDecimal(d);
    }

    public static Decimal ToDecimal(float f)
    {
        return Convert.ToDecimal(f);
    }

    public static Decimal ToDecimal(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return 0;
        // If datatype is Decimal, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Decimal"))
            return Convert.ToDecimal(obj);
        string str = obj.ToString();
        if (str == String.Empty)
            return 0;
        return Decimal.Parse(str);
    }

    public static object ToDBDecimal(Decimal d)
    {
        return d;
    }

    public static object ToDBDecimal(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        // If datatype is Decimal, then nothing else is necessary. 
        if (obj.GetType() == Type.GetType("System.Decimal"))
            return obj;
        string str = obj.ToString();
        if (str == String.Empty || !IsNumeric(str))
            return DBNull.Value;
        return Decimal.Parse(str);
    }


    public static Boolean ToBoolean(Boolean b)
    {
        return b;
    }

    public static Boolean ToBoolean(Int32 n)
    {
        return (n == 0) ? false : true;
    }

    public static Boolean ToBoolean(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return false;
        if (obj.GetType() == Type.GetType("System.Int32"))
            return (Convert.ToInt32(obj) == 0) ? false : true;
        if (obj.GetType() == Type.GetType("System.Byte"))
            return (Convert.ToByte(obj) == 0) ? false : true;
        if (obj.GetType() == Type.GetType("System.String"))
        {
            string s = obj.ToString().ToLower();
            return (s == "true" || s == "on" || s == "1") ? true : false;
        }
        if (obj.GetType() != Type.GetType("System.Boolean"))
            return false;
        return bool.Parse(obj.ToString());
    }

    public static object ToDBBoolean(Boolean b)
    {
        return b ? 1 : 0;
    }

    public static object ToDBBoolean(object obj)
    {
        if (obj == null || obj == DBNull.Value)
            return DBNull.Value;
        if (obj.GetType() != Type.GetType("System.Boolean"))
        {
            string s = obj.ToString().ToLower();
            return (s == "true" || s == "on" || s == "1") ? 1 : 0;
        }
        return Convert.ToBoolean(obj) ? 1 : 0;
    }
    public static bool IsDate(object o)
    {
        if (o == null)
            return false;
        else if (o is DateTime)
            return true;
        else if (o is String)
        {
            try
            {
                DateTime.Parse(o as String);
                return true;
            }
            catch
            {
            }
        }
        return false;
    }

    public static bool IsNumeric(object o)
    {
        if (o == null || o is DateTime)
            return false;
        else if (o is Int16 || o is Int32 || o is Int64 || o is Decimal || o is Single || o is Double)
            return true;
        else
        {
            try
            {
                if (o is String)
                    Double.Parse(o as String);
                else
                    Double.Parse(o.ToString());
                return true;
            }
            catch
            {
            }
        }
        return false;
    }
}
