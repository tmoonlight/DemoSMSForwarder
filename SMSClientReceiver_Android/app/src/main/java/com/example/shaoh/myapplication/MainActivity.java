package com.example.shaoh.myapplication;

import android.Manifest;
import android.content.ContentResolver;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import java.util.HashMap;
import java.util.Map;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        int REQUEST_CODE_ASK_PERMISSIONS = 123;
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // 需要验证的权限
        int hasWriteContactsPermission = checkSelfPermission(Manifest.permission.READ_SMS);
        if (hasWriteContactsPermission != PackageManager.PERMISSION_GRANTED) {
            // 弹窗询问 ，让用户自己判断
            requestPermissions(new String[] {Manifest.permission.CALL_PHONE},
                    REQUEST_CODE_ASK_PERMISSIONS);
            return;
        }

        int hasWriteContactsPermission2 = checkSelfPermission(Manifest.permission.RECEIVE_SMS);
        if (hasWriteContactsPermission2 != PackageManager.PERMISSION_GRANTED) {
            // 弹窗询问 ，让用户自己判断
            requestPermissions(new String[] {Manifest.permission.CALL_PHONE},
                    REQUEST_CODE_ASK_PERMISSIONS);
            return;
        }

        Uri smsInbox = Uri.parse("content://sms/");
        ContentResolver cr = getContentResolver();
        String[] projection = new String[]{"_id", "address", "person", "body", "date", "type"};
        Cursor cur = cr.query(smsInbox, projection, null, null, "date desc");
        TextView tv = (TextView) findViewById(R.id.shao);
        String tt = "";
        while (cur.moveToNext()) {
            String number = cur.getString(cur.getColumnIndex("address"));//手机号
            String name = cur.getString(cur.getColumnIndex("person"));//联系人姓名列表
            String body = cur.getString(cur.getColumnIndex("body"));//短信内容
            //至此就获得了短信的相关的内容, 以下是把短信加入map中，构建listview,非必要。
//            Map<String,Object> map = new HashMap<String,Object>();
//            map.put("num",number);
//            map.put("mess",body);
//            list.add(map);
            tt += number + " ";
            tt += name + " ";
            tt += body + " ";
            tv.setText(tt);

        }
    }

    //@Override

    public void startSend(View view) {
    }

    public void startTst(View view) {
    }
}
