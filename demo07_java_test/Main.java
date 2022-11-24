public class Main{
	public static void main(String[] args){
		int[] nums={2,0,2,1,1,0};
		sortColors(nums);
	}
	public static void sortColors(int[] nums) {
        int time_0=0;
        int time_1=0;
        int time_2=0;
        int[] result=new int[nums.length];
        for(int i=0;i<nums.length;i++){
            result[i]=1;
        }
        for(int i:result){
			System.out.println(i);
		}
        for(int i=0;i<nums.length;i++){
            if(nums[i]==0){
                result[time_0]=0;
                time_0++;
            }
            else if(nums[i]==2){
                result[result.length-1-time_2]=2;
                time_2++;
            }
        }
        for(int i:result){
			System.out.println(i);
		}
    }
}