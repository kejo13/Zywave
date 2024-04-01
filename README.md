Guide to implement this function to an email messaging system.

1.	Receive Emails:
a.	 Set up an email listener to receive incoming emails through SMTP, IMAP, or any other email protocol.

2.	Extract Email Content:
a.	Extract the email content, including the subject and body text.

3.	Invoke Email Filtering Service:
a.	Call the `FilterEmail` method of the `EmailFilterService` to filter the email content.
b.	Pass the extracted email text and a list of classified words to the `FilterEmail` method.

4.	Process Filtering Result:
a.	Receive the filtering result, which includes a boolean flag indicating whether classified words were found and the censored text.
b.	Depending on the result:
c.	If classified words are found, trigger an alert/notification to notify administrators or apply additional security measures.
d.	If no classified words are found, proceed with normal email processing.

5.	Send Processed Email:
a.	Send the processed email with censored text to the intended recipients.

6.	Integrate Controller and Service:
a.	The `EmailFilterController` exposes an HTTP endpoint (`FilterEmail`) to handle email content filtering.
b.	It accepts POST requests with JSON data containing `classifiedWords` and `emailText`.
c.	The controller invokes the `FilterEmail` method of the `EmailFilterService` to filter the email content.

7.	EmailFilterService:
a.	Contains the core logic for filtering email content based on a list of classified words.
b.	It iterates through the classified words and replaces them with asterisks in the email text if found.


Sample data:
{
  "classifiedWords": [
    "confidential", "sensitive", "classified", "secret", "proprietary"
  ],
  "emailText": "The confidential email contained sensitive, classified information and disclosed secret proprietary data."
}
