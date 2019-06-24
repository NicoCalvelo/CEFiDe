using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;
public class AWSManager : MonoBehaviour
{
    private static AWSManager _instance;
    public static AWSManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("AWS Manager is null");
            }
            return _instance;
        }
    }
    public string S3Region = RegionEndpoint.USEast2.SystemName;
    private RegionEndpoint _S3Region
    {
        get { return RegionEndpoint.GetBySystemName(S3Region); }
    }

    private AmazonS3Client _s3Client;
    public AmazonS3Client S3Client
    {
        get
        {
            if(_s3Client == null)
            {
                 _s3Client = new AmazonS3Client(new CognitoAWSCredentials(
                "us-east-2:0c2d850c-602a-44b4-94da-ed815dceae94", // identity Pool
                RegionEndpoint.USEast2 // region
                ), _S3Region);
            }
            return _s3Client;
        }
    }

    private void Awake()
    {
        _instance = this;

        UnityInitializer.AttachToGameObject(this.gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;



        S3Client.ListBucketsAsync(new ListBucketsRequest(), (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                responseObject.Response.Buckets.ForEach((S3b) =>
                {
                    Debug.Log("Bucket Name: " + S3b.BucketName);
                });
            }
            else
            {
                Debug.Log("AWS Error" + responseObject.Exception);
            }
        });
    }

    public void uploadToS3(string path, string mail)
    {
        FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

        PostObjectRequest request = new PostObjectRequest()
        {
            Bucket = "usuarioscefide",
            Key = "user" + mail,
            InputStream = stream,
            CannedACL = S3CannedACL.Private,
            Region = RegionEndpoint.SAEast1
        };
        S3Client.PostObjectAsync(request, (responseObj) =>
        {
            if (responseObj.Exception == null)
            {
                Debug.Log("Succesfuly posted to bucket");
            }
            else
            {
                Debug.Log("Exception occured during uploading: " + responseObj.Exception);
            }

        });
    }
}
