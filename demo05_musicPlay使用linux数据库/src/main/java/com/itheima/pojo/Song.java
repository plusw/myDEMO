package com.itheima.pojo;


// alt + 鼠标左键 整列编辑
public class Song{

    private String songName;
    private String singerName;
    private String path;
	private String id;


   
	public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }
   

    public String getsongName() {
        return songName;
    }

    public void setsongName(String songName) {
        this.songName = songName;
    }

    public String getsingerName() {
        return singerName;
    }

    public void setsingerName(String singerName) {
        this.singerName = singerName;
    }

    public String getpath() {
        return path;
    }

    public void setpath(String path) {
        this.path = path;
    }

    

    @Override
    public String toString() {
        return "Song{" +
                "songName=" + songName +
                ", singerName='" + singerName + '\'' +
                ", path='" +path + '\'' +
                '}';
    }
}
