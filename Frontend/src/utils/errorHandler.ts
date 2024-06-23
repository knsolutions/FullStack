export const handleError = (error: any) => {
  // Customize this function to handle errors as needed
  console.error("API call failed. Error:", error);
  throw error;
};
