using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class AWSManager : MonoBehaviour
{
    public user_Panel user_Panel;
    public userManager userManager;

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

    public void getList(string DNI)
    {
        string target = "user" + DNI;

        var request = new ListObjectsRequest()
        {
            BucketName = "ususarioscefide"
        };

        S3Client.ListObjectsAsync(request, (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                bool userFound = responseObject.Response.S3Objects.Any(obj => obj.Key == target);

                //usuario encontrado se descargara la info
                if(userFound == true)
                {
                    Debug.Log("user found");
                    buscarPlanillas(DNI);
                    S3Client.GetObjectAsync("ususarioscefide", target, (responseObj) =>
                    {
                        //read data and aply it to a case (object) to be used


                        if (responseObj.Response.ResponseStream != null)
                        {

                            byte[] data = null;

                            using(StreamReader reader = new StreamReader(responseObj.Response.ResponseStream))
                            {
                                using ( MemoryStream memory = new MemoryStream())
                                {
                                    var buffer = new byte[512];
                                    var byteReads = default(int);

                                    while((byteReads = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        memory.Write(buffer, 0, byteReads);
                                    }
                                    data = memory.ToArray();
                                }
                            }

                            using(MemoryStream memory = new MemoryStream(data))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                userInfo downloadedInfo = (userInfo)bf.Deserialize(memory);
                                userManager.Instance.newUserInfo = downloadedInfo;
                           
                                //Activate userPanel
                                user_Panel.isClient();
                            }
                        }
                    });
                }
                else
                {
                    Debug.Log("user not found");
                }
            }
            else
            {
                Debug.Log("Error getting List of items from S3: " + responseObject.Exception);
            }
        });
    }
    public void buscarPlanillas(string DNI)
    {
        string target = "user" + DNI;

        var request = new ListObjectsRequest()
        {
            BucketName = "resultadosevaluaciones"
        };

        //request Usuarios CEFiDe
        S3Client.ListObjectsAsync(request, (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                bool userFound = responseObject.Response.S3Objects.Any(obj => obj.Key == target);

                //usuario encontrado se descargara la info
                if (userFound == true)
                {
                    Debug.Log("Planillasuser found");
                    S3Client.GetObjectAsync("resultadosevaluaciones", target, (responseObj) =>
                    {
                        //read data and aply it to a case (object) to be used

                        if (responseObj.Response.ResponseStream != null)
                        {

                            byte[] data = null;

                            using (StreamReader reader = new StreamReader(responseObj.Response.ResponseStream))
                            {
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    var buffer = new byte[512];
                                    var byteReads = default(int);

                                    while ((byteReads = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        memory.Write(buffer, 0, byteReads);
                                    }
                                    data = memory.ToArray();
                                }
                            }

                            using (MemoryStream memory = new MemoryStream(data))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                userEvaluaciones downloadedInfo = (userEvaluaciones)bf.Deserialize(memory);
                                userManager.Instance.newUserEvaluaciones = downloadedInfo;
                                GameObject.Find("Display-Managers").GetComponent<displayManager>().setDisplays();
                            }
                        }
                    });
                }
                else
                {
                    Debug.Log("Planillas user not found");

                }
            }
            else
            {
                Debug.Log("Error getting List of items from S3: " + responseObject.Exception);
            }
        });
    }


    public void ingresar(string dni, string tresCaracteres)
    {
        string target = "user" + dni;


        var request = new ListObjectsRequest()
        {
            BucketName = "ususarioscefide"
        };

        S3Client.ListObjectsAsync(request, (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                bool userFound = responseObject.Response.S3Objects.Any(obj => obj.Key == target);

                //usuario encontrado se descargara la info
                if (userFound == true)
                {
                    Debug.Log("user found");
                    S3Client.GetObjectAsync("ususarioscefide", target, (responseObj) =>
                    {
                        //read data and aply it to a case (object) to be used
                        if (responseObj.Response.ResponseStream != null)
                        {

                            byte[] data = null;

                            using (StreamReader reader = new StreamReader(responseObj.Response.ResponseStream))
                            {
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    var buffer = new byte[512];
                                    var byteReads = default(int);

                                    while ((byteReads = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        memory.Write(buffer, 0, byteReads);
                                    }
                                    data = memory.ToArray();
                                }
                            }
                            using (MemoryStream memory = new MemoryStream(data))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                userInfo downloadedInfo = (userInfo)bf.Deserialize(memory);
                                userManager.Instance.newUserInfo = downloadedInfo;

                                if(userManager.Instance.newUserInfo.tresCaracteres == tresCaracteres)
                                {
                                    PlayerPrefs.SetString("userDNI", userManager.Instance.newUserInfo.DNI);
                                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                                }
                                else
                                {
                                    user_Panel.activarBarraError("Los tres caracteres son incorrectos");
                                }
                            }
                        }
                    });
                }
                else
                {
                    Debug.Log("user not found");
                    user_Panel.activarBarraError("Usuario no encontrado");
                }
            }
            else
            {
                Debug.Log("Error getting List of items from S3: " + responseObject.Exception);
            }
        });
    }


    public void uploadToS3(string path, string DNI)
    {
        FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

        PostObjectRequest request = new PostObjectRequest()
        {
            Bucket = "ususarioscefide",
            Key = "user" + DNI,
            InputStream = stream,
            CannedACL = S3CannedACL.Private,
            Region = RegionEndpoint.USEast2
        };
        S3Client.PostObjectAsync(request, (responseObj) =>
        {
            if (responseObj.Exception == null)
            {
                Debug.Log("Succesfuly posted to bucket");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Debug.Log("Exception occured during uploading: " + responseObj.Exception);
            }

        });
    }
}
